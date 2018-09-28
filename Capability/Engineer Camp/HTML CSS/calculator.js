

function compute() {
    var value1 = document.myForm.value1;
    var value2 = document.myForm.value2;
    var sel = document.myForm.select;

    switch(sel.options[sel.selectedIndex].value)
    {
        case 'Sum' : 
        document.getElementById('output').value = parseInt(value1.value) + parseInt(value2.value);
        return false;
            break;
        case 'Difference' : 
        document.getElementById('output').value = parseInt(value1.value) - parseInt(value2.value);
        return false;
            break;
        case 'Multiply' :
        document.getElementById('output').value = parseInt(value1.value) * parseInt(value2.value);
        return false;
            break;
        case 'Division' : 
        if(parseInt(value2.value)!=0)
        document.getElementById('output').value = parseInt(value1.value) / parseInt(value2.value);
        else
            alert("The second number cannot be zero under division operation.")
        return false;
            break;
    }

}