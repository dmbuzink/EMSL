// Grammar definition
grammar EMSL;

specification : name_definition (source_definition)+ (target_definition)+ (resource_definition)* EOF;

// Parser rules
name_definition : NAME STRING_LITERAL;

source_definition : SOURCE SOURCE_CSP_NAME WITH HOSTNAME HOSTNAME_VALUE WITH PORT PORT_VALUE;

target_definition : TARGET TARGET_CSP_NAME WITH HOSTNAME HOSTNAME_VALUE WITH PORT PORT_VALUE;

resource_definition : RESOURCE RESOURCE_NAME OF TYPE RESOURCE_TYPE (FROM SOURCE_CSP_NAME)? (TO TARGET_CSP_NAME)?
 (REQUIRES requires_definition_value)?;
 
requires_definition_value : RESOURCE_NAME |
                            RESOURCE_NAME AND requires_definition_value;


// Lexer rules
// Keywords
NAME : 'NAME ';

// CSP
SOURCE : 'SOURCE';
SOURCE_CSP_NAME : NAME_STRING_LITERAL;
TARGET : 'TARGET';
TARGET_CSP_NAME : NAME_STRING_LITERAL;
WITH : 'WITH';
HOSTNAME : 'HOSTNAME';
HOSTNAME_VALUE : STRING_LITERAL;
PORT : 'PORT';
PORT_VALUE : INT_LITERAL;

// RESOURCE
RESOURCE : 'RESOURCE';
RESOURCE_NAME : NAME_STRING_LITERAL;
OF : 'OF';
TYPE : 'TYPE';
RESOURCE_TYPE : 'K8S' | 'VM';
FROM : 'FROM';
TO : 'TO';
REQUIRES : 'REQUIRES';
AND : 'AND';

// Values
INT_LITERAL : '-'?[0-9] | '-'?[1-9][0-9]*;
NAME_STRING_LITERAL : [a-zA-Z0-9\-_]+;
STRING_LITERAL : [a-zA-Z0-9\-_:/.]+;


// IGNORE LINE ENDINGS
LINE_ENDINGS : [ \t\r\n]+ -> skip;