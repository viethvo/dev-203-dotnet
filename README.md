# Requirements

### Overview

The code base is the MVC web application that contains quite a few security holes
You need to:
- Go through the code and find out all security issues.
- Take note all issues ( in word/excel file ) with detail description for each (what the issue is, risk level, how to fix it, etc)
- Fix all found security issues.

### How to run the app

- Create SQL database in you local machine
- Run the script in SecurityCoding/script.sql to restore the database
- Update connection string "CustomerDB" to your database

### Identify the vulnerabilities
You read through the project source code and identify as much as possible the security risks. For each vulnerability, it is important that you understand the technical problem from the code and the threat of this vulnerability if it gets exploited. 

Hint 1: 

There is no restriction on using vulnerability scanning and static code analysis tools to identify these holes, e.g. OWASP ZAP, FindBugs, SonarQube… In fact, you are recommended to use them regularly.

Hint 2: 

The following vulnerabilities can be found, they are everywhere, your job is to find and eliminate them. The more the better, the list does not contain everything since there may be some vulnerabilities that the author don’t even know.

Security Misconfiguration (Error Handling Must Setup Custom Error Page)

Cross-Site Request Forgery (CSRF)

Cross-Site Scripting (XSS) attacks

Malicious File Upload.

Version Discloser

SQL Injection Attack.

Sensitive Data Exposure

Audit trail

Broken authentication and session management

Un-validated Redirects and Forwards

### Fix the security risks 
Once you understand the vulnerability, you modify the code to fix the issues. Make sure the risk go away and the new code won’t introduce any other issues. Don’t forget to put an explanation of your fix to a file before moving to next targets.
