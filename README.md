# HMO
I have a DB with 3 tables: member, vaccintaion and vaccinatiosDate,
vaccination presents the vaccination itself - the id and the manufactorer,
vaccinationsDate represents the event of a member that is getting a vaccination and includes date, member id, vaccination id etc.
the code was built daba-base first, in the Entity Framework techniqe, its divided to layers - entites, repository and service,
every layer is injected to the one above it with Dependency Injection,
Each entity has get, and add functions,
in addition the member repository contatins links based on chat gpt that return members that meets the needed requierments. 

The api of the project is a swagger. 
חלק ב':
אסטרטגיית איכות: 
                                                                                                                                                        Requirements Review:
1. מועד החשיפה צריך להיות מדויק יותר - ברמת הדקות ולא ברמת הימים.
2. אם הוכנס תאריך מלפני יותר משבועיים - תוצג הודעה שהאיכון לא רלוונטי מכיון שהכניסה לבידוד היא עד שבועיים מהחשיפה.
3. על המשתמש לאשר קבלת הודעה ואם לא אישר - יש לשלוח לו שוב.
4. יש להתאים את רדיוס האיכון בהתאם לשטח בו נמצא האדם, ולקחת בחשבון אם מדובר בשטח סגור או פתוח.
5. יש להמשיך לאכן את הפלאפונים לכל אורך תקופת הבידוד כדי לוודא שהאדם לא יוצא מבידוד.
6. במידה והנ. צ. אותרה במקום או בתאריך של סגר יש להטיל גם קנס על האדם.
7. יש לאכן את הפלאפון באופן שגם פלאפון טיפש יאוכן.

מקרי קצה:
1. יש לוודא שכל השדות מלאים.
2. לבדוק שהנ. צ. נמצא בתוך גבולות ישראל.
3. יש לבדוק שתאריך החשיפה הוא בן פחות משבועיים.
4. יש לוודא שתאריך ההחלמה הוא אחרי תאריך החשיפה ושאכן בוצעה בדיקה שלילית.
5. יש להערך למקרה שמערך האיכונים יהיה ריק.
 
