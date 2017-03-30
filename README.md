****
#BEGIN
* taken a piece of full json
* and class generating according to json
* a solution was created in accordance with the structure.
* project was organized according to Business Pattern and express by the Layer

----

HELPING RESOURCE FOR FORECAST CALCULATE
* https://www.casrilanka.com/casl/images/stories/EDBA/timeseries.pdf (Linear Time-Series Model, page 58)
* https://www.youtube.com/watch?v=zhQOCxBNTUo

----

#CLASS HIERACY
* Product --> Complemento(Objects)
** --> Det(Objects)
** --> Emit(Objects, EnderEmit() -> Objects )
** --> Ide (Objects, DhEmi() -> Objects)
** --> InfAdic (Objects)
** --> Total (Objects, IcmsTot () -> Objects)
** --> VersaoDocumento

----

**Identify a pattern on any set of fields that can help predict how much a customer will spend.
* Total BUFFET Product
* As Money: 75523.52 - As KG: 1101.014

**Calculate a sales forecast for the next week.
* Week 1 total sales = 24018.88 05-Jan-16 12:01:54 PM  09-Jan-16 02:24:16 PM
* Week 2 total sales = 32139.8 11-Jan-16 11:57:51 AM  16-Jan-16 03:14:40 PM
* Week 3 total sales = 34590.64 18-Jan-16 12:10:18 PM  23-Jan-16 02:56:35 PM
* next week sales forecast: 40821.5333333333