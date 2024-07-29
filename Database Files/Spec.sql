/*
Hearty Hearth
Spec:
recipes, meals, cookbooks, 
recipes in meals and books
recipe: most basic unit
recipe has cuisine type(master list), ingredients-measurement type and amount, need to be in specific order, record sequence of ingredient in recipe
directions have steps, in particular order, each step has a number. 
recipe has status-draft, not shown on website, published, archive-with date and time

Meals: name, course-diff course type, each course can have multiple recipes in it, only one of each course
need sequence in meal,
every recipe and ingredient, book, and meal must be unique

Cookbooks: name, price, recipes
sequence of recipes

both have active or inactive, no date

Pictures: anything with picture, belongs to type.
replace all spaces with '_' 
[name of type ex.ingredient] [name of thing ex.carrot] [.jpg]

Staff(user): first name, last name, user name

Q: You mentioned that one course can have multiple recipes. Is it important to differentiate between the main dish and side dishes? 
A: Yes, we need to record which recipe is the main dish and which are side dishes. This will allow us to display the course properly with the main dish in the center. If there is no main and side then we will display all the recipes in the course the same without emphasis on a single recipe.

Q: Can the status of a recipe go straight from drafted to archived? 
A: Yes, we may have a recipe which does not meet our standards and don't have time to work on it, so we archive it to get it out of the way, and then when we have time, we'll take it out of archive back to draft, and then publish it.

Q: Do you want to record how many calories there are in a recipe? 
A: Yes. 

Q: You mentioned that the dates when meals and cookbooks become active or inactive are not important to you. However, would you be interested in keeping record of the dates they were created instead? 
A: Yes.

Q from client: My website designer explained to me that the content for the web pages come from the database, and that the images on the web page are based on the file names, and those file name have to be part of the data that populates the site. The developer told me to double check with you that the file name will be in the database. Is that part of the spec?
A: Yes, for sure, I understood that from our interview and it will be done.

Q from client: Good, web designer also asked to double check that you got our picture file name format Entity_Entity_Name.jpg like Recipe_French_Toast.jpg. I think I previously mentioned to use dashes between the words, but we would actually need underscores instead. Sorry for being paranoid, its just we worked hard on this and want to ensure that the new database integrates smoothly with our existing system.
A: Yes, I got the revised format, will use underscores instead of dashes. And no worries about double checking, it is best to be clear especially at early stages of the development process because we are building the foundation of the system.
*/



