﻿>>>>>>>>>>>>>>>> Text

Точка обмена (exchange) — в нее отправляются сообщения. Точка обмена распределяет сообщения в одну или несколько очередей. При этом в точке обмена сообщения не хранятся. Точки обмена бывают трех типов: fanout — сообщение передается во все прицепленные к ней очереди; direct — сообщение передается в очередь с именем, совпадающим с ключом маршрутизации (routing key) (ключ маршрутизации указывается при отправке сообщения); topic — нечто среднее между fanout и exchange, сообщение передается в очереди, для которых совпадает маска на ключ маршрутизации

Очередь (queue) — здесь хранятся сообщения до тех пор, пока не будет забраны клиентом. Клиент всегда забирает сообщения из одной или нескольких очередей.







