# HMO
I have a DB with 3 tables: member, vaccintaion and vaccinatiosDate,
vaccination presents the vaccination itself - the id and the manufactorer,
vaccinationsDate represents the event of a member that is getting a vaccination and includes date, member id, vaccination id etc.
the code was built daba-base first, in the Entity Framework techniqe, its divided to layers - entites, repository and service,
every layer is injected to the one above it with Dependency Injection,
Each entity has get, and add functions,
in addition the member repository contatins links based on chat gpt that return members that meets the needed requierments. 

The api of the project is a swagger. 
