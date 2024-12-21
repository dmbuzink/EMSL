// Grammar definition
grammar EMSL;

specification : name_definition (source_definition)+ (target_definition)+ (resource_definition)* EOF;

// Parser rules
name_definition : NAME STRING_LITERAL;

source_definition : SOURCE STRING_LITERAL WITH HOSTNAME STRING_LITERAL WITH PORT INT_LITERAL;

target_definition : TARGET STRING_LITERAL WITH HOSTNAME STRING_LITERAL WITH PORT INT_LITERAL;

resource_definition : RESOURCE STRING_LITERAL OF TYPE RESOURCE_TYPE (FROM STRING_LITERAL)? (TO STRING_LITERAL)?
 (REQUIRES STRING_LITERAL (AND STRING_LITERAL)*)?;


// Lexer rules
// Keywords
NAME : 'NAME ';

// CSP
SOURCE : 'SOURCE';
TARGET : 'TARGET';
WITH : 'WITH';
HOSTNAME : 'HOSTNAME';
PORT : 'PORT';

// RESOURCE
RESOURCE : 'RESOURCE';
OF : 'OF';
TYPE : 'TYPE';
RESOURCE_TYPE : 'K8S' | 'VM';
FROM : 'FROM';
TO : 'TO';
REQUIRES : 'REQUIRES';
AND : 'AND';

// Values
INT_LITERAL : '-'?[0-9] | '-'?[1-9][0-9]*;
STRING_LITERAL : [a-zA-Z0-9\-_:/.]+;

// IGNORE LINE ENDINGS
LINE_ENDINGS : [ \t\r\n]+ -> skip;