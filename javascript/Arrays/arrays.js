function singSong() {
	console.log("Twinkle, twinkle, little start");
	console.log("how i wonder what you are!");
	console.log("etc")
}

function square(num) {
	console.log(num * num);
	return(num * num);
}

function sayHello(name) {
	console.log("Hello there! " + name + " !");
	return("Hello there! " + name + " !");
}


function capitalize(str){
	if(typeof str === "number") {
		return "that's not a string!"
	}
	return str.charAt(0).toUpperCase() + str.slice(1);
	//capitalize the first letter
}

function subtract(x,y) {
	return y - x;
	//subtract
}

function add(x,y){
	return x + y;
	//add
}

function multiply(x,y){
	return x * y;
	//multiply
}

function devide(x,y) {
	return x / y;
	//devide
}

function isEveen(num) {
	return num % 2 === 0;
	//return true if even
	//return false otherwise
}

function factorial(num){
	//define a result variable
	var result = 1;
	//calculate factorial and store value in result
	for(var i = 2; i <= num; i++){
		result = result * i;
	}
	//return the result variable
	return result;
	//factorial(4) 4 x 3 x 2 x 1
}

function kebabToSnake(str) {
	//replace all '-' with '_''s
	var newStr = str.replace(/-/g , "_");
	//return str
	return newStr;
}

function kebabToSpace(str) {
	//replace all '-' with ' 's
	var newStr = str.replace(/-/g , " ");

	return newStr;
}

function snakeToSpace(str) {
	//replace all '_' with ' 's
	var newStr = str.replace(/_/g , " ");

	return newStr;
}

window.setTimeout(function() {
  // put all of your JS code from the lecture here
  var todos = [];

  var input = prompt("What would you like to do?");



  while(input !== "quit") {
  	//handle input
  	//ask again for new input
	if(input === "list") {
		listTodos();
  	} else if(input == "new") {
  		addTodo();
  	} else if (input === "delete"){
  		deleteTodo();
  	}
  	//ask for new todo again
  	var input = prompt("What would you like to do?");
  }
  console.log("You Quit the APP");



function addTodo() {
	//ask for new todo
  	var newTodo = prompt("Enter new todo");
  	//add to todos array
	todos.push(newTodo);
	console.log("Added todo: " + newTodo)
}

function deleteTodo() {
	//ask for index of todo to be deleted
  	var index = prompt("Enter index of todo to delete")
  	//delete that todo
  	//splice()
  	todos.splice(index,1)
  	console.log("Deleted Todo: " + index);
}

function listTodos() {
	console.log("*************")
	todos.forEach(function(todo, i){
	console.log(i + ": " + todo);
	});
console.log("*************")
}

}, 500);

