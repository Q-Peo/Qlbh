window.onload = function () {
    setTimeout("switch_Image()", 2000);
}
var current = 1;
var num_image = 4;
function switch_Image() {
    current++;
    document.images['image'].src = 'Images/slide-' + current + '.jpg';
    if (current < num_image) {
        setTimeout("switch_Image()", 2000);
    } else if (current == num_image) {
        current = 0;
        setTimeout("switch_Image()", 2000);
    }
}