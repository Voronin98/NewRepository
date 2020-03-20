# Математическая модель Солнечной Системы
[Ссылка на казахский сайт с математической моделью](http://www.dereksiz.org/matematicheskaya-modele-solnechnoj-sistemi.html)

## Версии кода
 № | Ссылка                                                        | Описание кода
---|---------------------------------------------------------------|----------------------------------------------------------------------
 1 | [Код вращения планет от 19.03.2020 16:40](/Rotate%20File/Rotate.cs) | Период обращения Плутона близок к ожидаемому значению - ~75 сек (примечание: Плутон ускорен в 100,000,000 раз). Примечание к коду: эталон говнокода: куча ненужных комментариев, в которых тяжело отыскать рабочий код, а уж тем более нормальный рабочий код; Половина методов вообще не нужна; Unity отказывается воспринимать малые числа и сводит их к единице (не вижу смысла решать эту проблема, так как без этих не рабочих методов и игноров малых чисел, Плутон имеет нормальный период. Да и сдался вам этот сраный Плутон!); не учтены кеплеровы элементы орбиты (за исключением наклонения (i)). 
 2 | [Код вращения планет от 19.03.2020 18:40](/Rotate%20File/Rotate%2019_03_2020.cs) |Плутон работает, Земля пока нет. Избавился от совсем лишних комментариев. Перевёл Землю с RotateAround на вращение по эллипсу (также как у Плутона). Перевёл параметры Земли в СИ, однако Земля должна вращаться в раз 10-20 быстрее, но этого не происходит. Сегодня лень над этим думать. Время ещё есть.
 3 | [Код вращения планет от 20.03.2020 15:58](Rotate%20File/Rotate%2020_03_2020.cs) |Работа с Землёй принесла успехи. Теперь не надо её ускорять в 100,000,000 раз, лишь в 1,000,000. Однако всё-равно Земля должна ходить быстрее (в ~120 раз). Тоже самое пытался применить к Плутону. Он сильно замедлился, но вращение всё-таки видимо. Если Земля будет доработа и скорость вращения достигнет ожидаемой, то с остальными планетами должно быть также.
 4 | [Код вращения планет от ..2020 :]() |-
