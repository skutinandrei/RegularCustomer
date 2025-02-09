Напишите программу "Постоянный покупатель" с двумя классами:

Shop (Магазин)
Customer (Покупатель)
В классе Shop должна храниться информация о списке товаров (экземпляры классов Item). Также в классе Shop должны быть методы Add (для добавления товара) и Remove (для удаления товара).
В классе Item должны быть свойства Id (идентификатор товара) и Name (название товара).

В классе Customer должен быть метод OnItemChanged, который будет срабатывать, когда список товаров в магазине обновился. В этом методе надо выводить в консоль информацию о том, какое именно изменение произошло (добавлен товар с таким-то названием и таким-то идентификатором / удален такой-то товар).

В основном файле программы создайте Магазин, создайте Покупателя. Реализуйте через ObservableCollection возможность подписки Покупателем на изменения в ассортименте Магазина - все изменения сразу должны отображаться в консоли (должен срабатывать метод Customer.OnItemChanged).

По нажатии клавиши A добавляйте новый товар в магазин. Товар должен называться "Товар от <текущее дата и время>", где вместо <текущее дата и время> подставлять текущую дату и время.
По нажатии клавиши D спрашивайте какой товар надо удалить. Пользователь должен ввести идентификатор товара, после чего товар необходимо удалить из ассортимента магазина.
По нажатии клавиши X выходите из программы.

Добавьте в Магазин несколько товаров, удалите какие-то из них - убедитесь, что сообщения выводятся в консоль.
