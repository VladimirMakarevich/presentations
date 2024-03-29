﻿>>>>>>>>>>>>>>>> Text

Model-Driven Design (Проектирование по модели) и Ubiquitous Language (Единый язык).

Supple Design (Гибкий дизайн), который опирается на трех китов – Intention-Revealing Interfaces (Информативный интерфейс), Assertions (Утверждения a.k.a Контракты) и Side-Effect-Free Functions (Функции без побочных эффектов).

Bounded Context (Ограниченный контекст)

Core Domain – Смысловое ядро

Translation Layer – Слой преобразования

Anticorruption Layer (Предохранительный слой)

Объяснения понятий связности и связанности (coupling и cohesion) обычно подаются с технической точки зрения, оценивая решения с точки зрения распределения ассоциаций и взаимодействий. Но не только код разделяется на МОДУЛИ, но и понятия предметной разделяются аналогичным образом. Существует предел на количество понятий, о которых может думать человек в один момент времени (отсюда слабая связанность, low coupling). Неправильно разделенные или смешанные в кучу несвязанные понятия очень сложно понять (отсюда сильная связанность, high cohesion).

что должно быть «корнем» такой группы объектов (Aggregate Root)?



>> Единый язык (Ubiquitous Language)
Вон Вернон в своей книге предлагает использовать следующие способы:
Создание диаграмм физической и концептуальной предметной областей и нанесение на них меток, обозначающих имена и действия. Такие диаграммы носят неформальный характер, поэтому нет смысла использовать формальное моделирование (как UML).
Создание глоссария с простыми определениями, а также альтернативными терминами с оценкой их перспективности. Таким образом разрабатываются устойчивые словосочетания единого языка.
Создание документации вместо глоссария. Эта документация будет содержать неформальные диаграммы или важные понятия, связанные с программным обеспечением.
Обсуждение готовых фраз с остальными членами команды, которые не могут сразу освоить глоссарий или другие письменные документы.


>> Ограниченный контекст (Bounded context)
– это явная граница, внутри которой существует модель предметной области, которая отображает единый язык в модель программного обеспечения.

В каждом ограниченном контексте существует только один единый язык.
Ограниченные контексты являются относительно небольшими, меньше чем может показаться на первый взгляд. ограниченный контекст достаточно велик только для единого языка изолированной предметной области, но не больше.
Единый значит «вездесущий» или «повсеместный», т. е. язык, на котором говорят члены команды и на котором выражается отдельная модель предметной области, которую разрабатывает команда.
Язык является единым только в рамках команды, работающей над проектом в едином ограниченном контексте.
Попытка применить единый язык в рамках всего предприятия или что хуже, среди нескольких предприятий, закончится провалом.

>> Предметная область, предметная подобласть, смысловое ядро
Предметная область (Domain) – это то, что делает организация, и среда, в которой она это делает.

Смысловое ядро – это подобласть, имеющая первостепенное значение для организации. 

Если моделируется определенный аспект бизнеса, который важен, но не является смысловым ядром, то он относится к служебной подобласти (Supporting subdomain). Бизнес создает служебную подобласть, потому что она имеет специализацию. Если она не имеет специального предназначения для бизнеса, а требуется для всего бизнеса в целом, то ее называют неспециализированной подобластью (Generic subdomain). Эти виды подобластей важны для успеха бизнеса, но не имеют первоочередного значения. Именно смысловое ядро должно быть реализовано идеально, поскольку оно обеспечивает преимущество для бизнеса.



>> Пространство задач и пространство решений
Пространство задач – части предметной области, которые необходимы, чтобы создать смысловое ядро. Это комбинация смыслового ядра и подобластей, которое это ядро должно использовать.
Пространство решений – один или несколько ограниченных контекстов, набор конкретных моделей программного обеспечения. Разработанный ограниченный контекст – это конкретное решение, представление реализации.


>> Карта контекстов (Context map)
партнерство (Partnership).
общее ядро (Shared kernel).
разработка заказчки-поставщик (Customer-supplier development).
конформист (Conformist).
предохранительный уровень (Anticorruption layer).
служба с открытым протоколом (Open host service).
общедоступный язык (Published language).
отдельное существование (Separate ways).
большой комок грязи (Big ball of mud).


>>>>>>>>>>> Part 2
>> Сущность (Entity)
>> Объект-Значение (Value Object)
>> Служба Предметной Области (Domain Service)
>> Событие (Domain Event)
>> Модуль (Module)
>> Агрегат (Aggregate)
>> Фабрика (Factory)
>> Хранилища (Repository)
 














