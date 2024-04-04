6002CEM - Mobile Food Delivery App (Mexican Fiesta)
main-DB is the final branch with all features implemented.

Motivation:

The initial plan for the Mexican Fiesta was to create a menu including different categories such as starters, mains, desserts and drinks. However, in the process of planning out the different features to implement, there would be many pages with the same templates and layouts. I decided that I did not want to have the same type of feature just being repeated throughout the app because it would be boring and look lazy. This is when the idea of a food ordering app like Uber Eats came about as this provided different feature opportunities to be able to explore and delve into. The features that were put into effect are going to be covered in the section below in a lot more detail. 

Features:

The first feature to be shown is allowing users to be able to filter products available to the user through a search bar. The search bar looks for any products that contain the character string that was inputted by the user. If there is a result, the product will come up with the matching input string, otherwise no products will display on the page. 

Allowing users to be able to add different products to the cart will be the next feature. The home page, which shows the most popular products that are chosen at random every time the app loads, or the products page, which contains every product, are the two pages on the app where users can add products. A user can change the quantity of a product that will automatically appear in their cart when the quantity of the product is greater than or equal to 1.

Another feature that is going to be shown is allowing users to view what products they have added to the cart. Additionally, a user will have the option to remove specific products from their cart or empty their cart entirely, allowing them to start from scratch. However, on the rare occasion that a user may accidentally remove a particular item, they will have 3 seconds to undo the removal of the product. On the cart page, the total amount that the order is going to cost will be displayed and when the user is satisfied with the products in the cart, they can then make an order. When a user makes an order, they will be redirected to a page confirming their order and the cart page will be cleared and ready for another order to be placed. 

The final features available to users is the ability to make a list of the products they want and the people they are ordering for. Users can execute all CRUD functions (GET, POST, PUT, and DELETE) with this feature. A local database was used to keep track of the data that users entered into the entry fields made this feature possible. 

The app showcased more than just these features; a tabbar and flyout navigation system linking the home, cart, and notes pages was built in. The app was given structure through the use of various layouts and collection views, which made it appear more user friendly and appealing to users. Also, in the making of the app, a supabase feature was attempted which can be seen on github which would allow users with authorised access to add more products on the app. However, this was not achieved, so a local database feature using Sqlite was implemented in its place. 
