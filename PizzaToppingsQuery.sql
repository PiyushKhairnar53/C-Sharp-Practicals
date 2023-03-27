SELECT 
  p1.topping_name +','+ p2.topping_name+','+ p3.topping_name AS pizza_toppings,
  p1.ingredient_cost + p2.ingredient_cost + p3.ingredient_cost AS cost_of_pizza
FROM PIZZA AS p1
CROSS JOIN
  PIZZA AS p2,
  PIZZA AS p3
WHERE p1.topping_name < p2.topping_name
  AND p2.topping_name < p3.topping_name
ORDER BY cost_of_pizza DESC;
