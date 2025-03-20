# Задание / Task: 
Есть несколько заводов, каждый из которых выпускает продукцию одного типа. Например, завод A выпускает продукт "a", завод B - продукт "b" и т.д. Каждый завод выпускает разное количество своей продукции. Завод А - n единиц в час, B - 1.1n единиц в 1 час, С - 1.2n единиц продукции в час и т.д. Размерами продукции пренебрегаем и предполагаем одинаковыми для всех фабрик, однако каждый продукт имеет уникальные свойства: название, вес, тип упаковки.

There are several factories, each of which produces products of the same type. For example, plant A produces product “a”, plant B produces product “b”, etc. Each factory produces a different quantity of its product. Plant A produces n units per hour, B produces 1.1n units per hour, C produces 1.2n units per hour, etc. We neglect the size of products and assume the same for all factories, but each product has unique properties: name, weight, type of packaging.

---
Необходимо организовать эффективное складирование продукции заводов, а так же доставку в торговые сети из расчёта, что склад может вмещать M * (сумму продукции всех фабрик в час). По заполнению склада не менее чем на 95% склад должен начинать освобождаться от продукции следующим образом. Продукцию со склада забирает грузовой транспорт различной вместимости (не менее двух видов грузовиков). Грузовик может забирать продукцию разных типов.

It is necessary to organize efficient warehousing of products of factories, as well as delivery to retail chains, based on the calculation that the warehouse can accommodate M * (the sum of products of all factories per hour). When the warehouse is at least 95% full, the warehouse should start to be emptied of products as follows. The products are taken from the warehouse by a truck of different capacities (at least two types of trucks). A truck can pick up products of different types.

---
М может быть переменным, но не менее 100. Число заводов может быть переменным, но не менее трёх. n может быть переменным, но не менее 50

Необходимо вывести следующие результаты работы алгоритма:

- последовательность поступления продукции на склад (фабрика, продукт, число единиц)

- необходимо подсчитать статистику, сколько продукции и какого состава в среднем перевозят грузовики.

Приложение предлагается реализовать многопоточным.

M may be variable, but not less than 100. The number of plants can be variable, but not less than three. n can be variable, but not less than 50

It is necessary to output the following results of the algorithm:

- the sequence of products entering the warehouse (factory, product, number of units)

- It is necessary to calculate the statistics, how many products and what composition are transported by trucks on average.

The application is proposed to be implemented multithreaded.

---
В данной программе: 
- M = 100;
- N = 50;
- Количество грузовиков: 2 (большой и малый);
- Количество фабрик: 3 (фабрика А, фабрика B, фабрика С).

In this program: 
- M = 100;
- N = 50;
- Number of trucks: 2 (big and small);
- Number of factories: 3 (factory A, factory B, factory C).
