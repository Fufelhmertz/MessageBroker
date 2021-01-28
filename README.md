# MessageBroker
Библиотека, реализующая простой брокер сообщений

Как запустить?
-------------------------------------------------------------
* Подключить библиотеку через Reference
* Пример использования 

```C#
//Создаем сообщение
var message = new Message("test");

//Создаем подписанта
var subcriber = new Subscriber("TestUser");

var messageBroker = new Broker();
 
//Добавляем подписанта в рассылку
messageBroker.Subscribe(subcriber);
 
//Выполняем рассылку. Результат выводится на консоль
messageBroker.Post(message);
 
//Удаляем подписанта из рассылки
messageBroker.UnSubscribe(subcriber);
 
```
