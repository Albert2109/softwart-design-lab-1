# Приниципи в коді

## DRY (Don't Repeat Yourself)
• Логіка, що виконує певну задачу, інкапсулюється в одному місці,  метод [Normalize()](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Money.cs#L81-L88) у класі Money відповідає за приведення значень копійок у правильний формат, що дозволяє уникнути повторення цього коду в інших місцях.

## KISS (Keep It Simple, Stupid)
• Код структурований просто та зрозуміло. Кожен клас виконує лише одну функцію:
 – [Money](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Money.cs) обробляє операції з грошовими значеннями та конвертацією,
 – [Product](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Product.cs) містить дані про продукт і метод для встановлення ціни,
 – [Warehouse](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Warehouse.cs) займається управлінням колекцією продуктів,
 – [TransactionLogger](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/TransactionLogger.cs) відповідає за ведення журналу транзакцій,
 – [WarehouseManager](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/WarehouseManager.cs) інтегрує роботу складу та логування.
Це забезпечує легкість розуміння та підтримки коду.

## SOLID Принципи

### Single Responsibility Principle (SRP)
 • Клас [Product](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Product.cs) відповідає лише за властивості продукту та операції з ціною, а [Reporting](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Reporting.cs) – за формування звітів.

### Open/Closed Principle (OCP)
 • Використання інтерфейсів, таких як [ITransactionLogger](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/ITransactionLogger.cs) та [Convert](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Convert.cs), дозволяє розширювати функціональність (додаючи нові реалізації) без зміни існуючого коду.

### Liskov Substitution Principle (LSP)
 • Об’єкти, що реалізують інтерфейси ( Money реалізує [Convert](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Convert.cs)), можна використовувати як їх базовий тип без зміни логіки роботи програми.

### Interface Segregation Principle (ISP)
 • Інтерфейси є спеціалізованими і містять лише необхідні методи. [ITransactionLogger](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/ITransactionLogger.cs) містить лише методи, пов’язані з логуванням транзакцій, що робить їх компактними та зрозумілими.

### Dependency Inversion Principle (DIP)
 • Клас [WarehouseManager](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/WarehouseManager.cs) залежить від абстракції ([ITransactionLogger](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/ITransactionLogger.cs)), а не від конкретної реалізації, що забезпечує гнучкість і легкість підміни компонентів.

## YAGNI (You Aren't Gonna Need It)
• Код містить лише ті методи та властивості, які необхідні для поточних задач ( метод [DeclarePrice](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Product.cs#19-41) в [Product](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Product.cs) виконує тільки актуальне порівняння і встановлення ціни), що запобігає надмірному ускладненню системи.

## Composition Over Inheritance
• Структура програми ґрунтується на композиції:
 – Клас [WarehouseManager](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/WarehouseManager.cs) приймає об’єкти [Warehouse](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Warehouse.cs) та [ITransactionLogger](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/ITransactionLogger.cs) як залежності, використовуючи їх як складові частини, а не успадковуючи їх.
Це дозволяє більш гнучко комбінувати функціональність і мінімізує залежність від ієрархій спадкування.

## Program to Interfaces, Not Implementations
• Використання інтерфейсів (наприклад, [Convert](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Convert.cs) та [ITransactionLogger](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/ITransactionLogger.cs)) стимулює програмування через абстракції.
 – Клас [Money](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Money.cs) реалізує [Convert](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Convert.cs), що дозволяє використовувати його як абстрактний тип для конвертації,
 – [WarehouseManager](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/WarehouseManager.cs) взаємодіє з [ITransactionLogger](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/ITransactionLogger.cs), що дозволяє замінити конкретну реалізацію логування без зміни логіки менеджера.

## Fail Fast
• Код одразу перевіряє валідність вхідних даних і генерує виключення при порушенні умов:
 – Встановники властивостей (наприклад, [money](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Money.cs#9-27), [penny](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Money.cs#29-48), [exchangeRate](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Money.cs#52-69) у класі [Money](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/Money.cs)) перевіряють, чи значення не є меншими або рівними нулю, і в разі порушення виводять повідомлення про помилку,
 – Методи [RecordIn](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/TransactionLogger.cs#18-26) та [RecordOut](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/TransactionLogger.cs#28-36) у [TransactionLogger](https://github.com/Albert2109/softwart-design-lab-1/blob/main/Lab1/Task1/Menu/TransactionLogger.cs) одразу перевіряють параметри (чи не є об’єкт product нульовим, чи кількість є додатною), забезпечуючи швидке виявлення помилок.

