var numbSquares = 6;
var pickedColor;
var colors = [];

var h1 = document.querySelector("h1");
var squares = document.querySelectorAll(".square");
var colorDisplay = document.getElementById("colorDisplay");
var messageDisplay = document.querySelector("#message");
var resetButton = document.querySelector("#reset");
var modeButtons = document.querySelectorAll(".mode");


init();



resetButton.addEventListener("click", function(){
	reset();
});

/*colorDisplay.textContent = pickedColor;*/

for(var i = 0; i < squares.length; i++){
	//add click listners to squares
	squares[i].addEventListener("click", function(){
		//grabcolor of clicked square
		var clickedColor = this.style.backgroundColor;
		//compare color to pickedColor
		if(clickedColor === pickedColor){
			//correct
			messageDisplay.textContent = "Correct!";
			changeColors(clickedColor);
			h1.style.backgroundColor = clickedColor;
			resetButton.textContent = "Play Again?";
		} else {
			//wrong
			this.style.backgroundColor = "#232323";
			messageDisplay.textContent = "Try Again";
		
		}
	})
};

function init(){

  setupModeButtons();
  setupSquares();
  reset();
}

function setupSquares(){
	 for(var i = 0; i < squares.length; i++){
	//add click listners to squares
	squares[i].addEventListener("click", function(){
		//grabcolor of clicked square
		var clickedColor = this.style.backgroundColor;
		//compare color to pickedColor
		if(clickedColor === pickedColor){
			//correct
			messageDisplay.textContent = "Correct!";
			changeColors(clickedColor);
			h1.style.backgroundColor = clickedColor;
			resetButton.textContent = "Play Again?";
		} else {
			//wrong
			this.style.backgroundColor = "#232323";
			messageDisplay.textContent = "Try Again";
		
		}
	});
  }
}

function setupModeButtons(){
	for(var i = 0; i < modeButtons.length; i++){
	modeButtons[i].addEventListener("click", function(){
		modeButtons[0].classList.remove("selected");
		modeButtons[1].classList.remove("selected");
		this.classList.add("selected");
		this.textContent === "Easy" ? numbSquares = 3: numbSquares = 6;
		reset();
	});
  }
}

function reset(){
	//generate all new colors
	colors = generateRandomColors(numbSquares);
	//pick a new random color from array
	pickedColor = pickColor();
	//change colorDisplay to match picked color
	colorDisplay.textContent = pickedColor;
	resetButton.textContent= "New Colors";
	messageDisplay.textContent = "";
	//change colors of squares
	for(var i = 0; i < squares.length; i++) {
		if(colors[i]){
			squares[i].style.display = "block";
			squares[i].style.background = colors[i];
		} else {
			squares[i].style.display = "none";
		}
	}
	h1.style.background= "steelblue";
};

function changeColors(color){
	//loop trough all squares
	for(var i = 0; i < squares.length; i++){
		//change each color to match given color
		squares[i].style.background = color;
	}
	
};

function pickColor(){
	var random = Math.floor(Math.random() * colors.length);
	return colors[random];
};

function generateRandomColors(num){
	//make an array
	var arr = []
	//add num random colors to array
	for(var i = 0; i < num; i++){
	//get random color and push into array
		arr.push(randomColor())
		
	}
	//return that array
	return arr;
};
function randomColor(){
	//pick a "red" from 0 - 255
	var r = Math.floor(Math.random() * 256);
	//pick a "green" from 0 - 255
	var g = Math.floor(Math.random() * 256);
	//pick a "blue" from 0 - 255
	var b = Math.floor(Math.random() * 256);
	return "rgb(" + r + ", " + g + ", " + b + ")"
};