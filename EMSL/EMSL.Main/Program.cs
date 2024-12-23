// See https://aka.ms/new-console-template for more information

using EMSL.Language;

var input = """
            NAME FreshCoffee-Migration-alpha
            
            // Sources
            SOURCE CSP_A
                WITH HOSTNAME https://csp-a.ecofed.nl
                WITH PORT 11037
                
            SOURCE CSP_G
                WITH HOSTNAME https://csp-G.ecofed.nl
                WITH PORT 11037
            
            // Targets
            TARGET CSP_B
                WITH HOSTNAME https://csp-b.ecofed.nl
                WITH PORT 11037
            
            // Resources
            RESOURCE FC-FrontEnd
                OF TYPE K8S
                FROM CSP_A // <- optional, if you have multiple sources, defaults to first
                TO CSP_B // <- optional, if you have multiple targets, defaults to second
                REQUIRES FC-BackEnd AND FC-IAM
            
            RESOURCE FC-BackEnd
                OF TYPE K8S
                FROM CSP_G
                TO CSP_B 
                REQUIRES FC-Database
                
            RESOURCE FC-Database
                OF TYPE K8S
                FROM CSP_A
                TO CSP_B
                
            RESOURCE FC-IAM
                OF TYPE K8S
                FROM CSP_A
                TO CSP_B
                REQUIRES FC-IAM-Database
            
            RESOURCE FC-IAM-Database
                OF TYPE K8S
                FROM CSP_A
                TO CSP_B
            """;

var specification = EmslManager.ParseInput(input);
Console.WriteLine(specification.Name);