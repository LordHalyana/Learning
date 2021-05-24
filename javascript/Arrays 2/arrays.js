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

function printReverse(arr) {
	for(var i = arr.length - 1; i>= 0; i--){
		console.log(arr[i]);
	}
}

function isUniform(arr) {
	var first = arr[0];
	for(var i = 1; i < arr.length; i++){
		if(arr[1] !== first){
			return false;
		}
	}
	return true;
}

function sumArray(arr) {
	var total = 0;
	arr.forEach(function(element){
		total += element;
	});
	return total;
}

function max(arr){
	var max = arr[0];
	for(var i = 1; i < arr.length; i++){
		if(arr[i] > max){
			max = arr[i];
		}
	}
	return max;
}

Array.prototype.myForEach = function(func) {
	//lop trough array//
	for(var i = 0; i < this.length; i++){
		//call func for each item in array
		func(this[i]);
	}
}

window.setTimeout(function() {
  // put all of your JS code from the lecture here
  






}, 500);

