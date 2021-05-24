var secretNumber = 4;

var stringGuess = prompt("Guess a number");
var guess = Number(stringGuess);

if (guess === secretNumber) {
	alert("You win a smooch!");
}

else if(guess > secretNumber) {
	alert("Too high, try again!");
}

else {
	alert("Too low, try again!");
}
