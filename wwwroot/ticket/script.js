var colors = ['#FF5733', '#FFC300', '#C70039', '#900C3F', '#581845', '#1E8449', '#3498DB', '#9B59B6'];

function changeBackgroundColor() {
    var randomIndex = Math.floor(Math.random() * colors.length);
    var randomColor = colors[randomIndex];

    document.body.style.backgroundColor = randomColor;
}

window.onload = changeBackgroundColor;