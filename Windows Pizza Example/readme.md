Please look at the change history fore the files in the repository.

1. intiial implemnetation uses an overidden member method to add toppings. This is still a valid implemnetation but is confusing when using it becasue you add toppings to topping explicitly. It also required coding to a concrete decorator instance.
2. the next implementation switched to using a constructor input argument which made it clearer that you are "wrapping" items as you "go down"
3. the final implementation codes the example to the Pizza interface which greatly increases readability.


![pizza output](https://github.com/bobthearsonist/DecoratorPattern/blob/master/Windows%20Pizza%20Example/Output%20Of%20Pizza%20Application.png)
