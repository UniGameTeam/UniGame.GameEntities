Remote User Data Module
=======
Примеры работы с модулем можно посмотреть в репозитории https://github.com/Giperbore1/UserDataModule
## Authorization 
Содержит набор абстратных классов для авторизации на 14.07.19 код прочих частей модуля на них не ссылается, при появлении модуля для работы с социалками необходимо будет перенсти в него

## MutableObject
Содержит набор абстракций для работы с удаленными данными.

BaseMutableRemoteObjectFacade<T> - реактивная прослойка между RemoteObjectHandler и внешним кодом от нее необходимо наследовать обертки для данных клиентского кода. Изменения полей предполагаются по средствам MutableChild и MutableObjectReactiveProperty. Для ReactiveProperty есть protected метод CreateReactiveProperty<T>. ВАЖНО! При работе с такими объектами все изменения применяются локально, но для отправки изменений на сервер необходимо дергать метод CommitChanges, рекомендуется дергать CommitChanges после каждой команды изменяющей данные (например: есть команда купить товар, она состоит из двух частей: уменьшить количество золота, увеличить количество товара на складе. CommitChanges нужно вызвать после завершения всех операций).

MutableChild - менее функциональная версия BaseMutableRemoteObjectFacade предназначенная для оборачивая дочерних данных и предоставляющая те же методы. Работа с контруктором возможна со стороны клиентского кода, но для корректной работы внутри BaseMutableRemoteObjectFacade необходимо при создании вызывать RegisterChild

Для оборачивания типов Dictionary и List есть соответсвенно классы MutableLsit, MutableDictionary. Обращаться с ними следует так же как c MutableChild

## Pvp 
Содержит PvpRegistrationApi - интерфейс для регистрации/отмены регистрации в Пвп. 
PvpPoolData - сериализуемый класс для получения метаинформации о состоянии пвп пула на сервере

## RemoteData

Содержит:

RemoteObjectHandler - базовая абстракция для работы с данными хранящимися на сервере предоставляет базовые методы для загрузки / изменения

RemoteObjectsProvider - абстрактная фабрика RemoteObjectHandler

## SharedMessages

Содержит: 

Набор абстракций для работы с сообщения пользователя на сервере. 

BaseSharedMessagesStorage - абстракция для работы с серверным хранилищем данных

SharedMessagesService - сервис с которым нужно работать в клиентском приложении. Предоставляет методы для получения сообщений, регистрации обработчиков.

ISharedMessageProccessor - интерфейс обработчика сообщений, необходимо реализовать чтобы принимать сообщения