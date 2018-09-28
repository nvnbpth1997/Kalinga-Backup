function formValidate()
{
    var sel = document.myForm.select;
    console.log(sel.options[sel.selectedIndex].value);

    var fname = document.myForm.firstname;
   if( fname.value == "" )
   {
      alert( "Please provide your first name!" );
      fname.focus();
      return false;
   }

   var lname = document.myForm.lastname;
   if( lname.value == "" )
   {
      alert( "Please provide your last name!" );
      lname.focus();
      return false;
   }
   
   var address = document.myForm.address;
   if (address.value == "")                              
    {
        window.alert("Please enter your address!");
        address.focus();
        return false;
    }

    var city = document.myForm.city;
    if (city.value == "")                              
     {
         window.alert("Please enter your city name!");
         city.focus();
         return false;
     }

     var state = document.myForm.state;
     if (state.value == "")                              
      {
          window.alert("Please enter your state name!");
          state.focus();
          return false;
      }

      var postalcode = document.myForm.postalcode;
      if( postalcode.value == "" || isNaN( postalcode.value ) ||  postalcode.value.length != 6 )
      {
         alert( "Please provide a zip in the format ######!" );
         postalcode.focus() ;
         return false;
      }
   
      var country = document.myForm.country;
      if( country.value == "" )
      {
         alert( "Please provide your country name!" );
         country.focus();
         return false;
      }
   
      var phone = document.myForm.phone;
      if(phone.value == "")
      {
               alert('Fill the Input phone number!');
               phone.focus();
               return false;
       }
   
       if(isNaN(phone.value)){
           alert('Please specify your correct phone Number!');
           phone.focus();
           return false;
       }

   var email = document.myForm.email;
   if( email.value == "" )
   {
      alert( "Please provide your Email!" );
      email.focus() ;
      return false;
   }

   if (email.value.indexOf("@", 0) < 0)                
    {
        window.alert("Please enter a valid e-mail address!");
        email.focus();
        return false;
    }
  
    if (email.value.indexOf(".", 0) < 0)                
    {
        window.alert("Please enter a valid e-mail address!");
        email.focus();
        return false;
    }

    var radios = document.myForm.radio;
    var formValid = false;

    var i = 0;
    while (!formValid && i < radios.length) {
        if (radios[i].checked) 
            formValid = true;
        i++;        
    }

    if (!formValid) alert("Must check some payment option!");
        return formValid;

        var agree = document.myForm.confirm;
        if(!agree.checked){
            alert('Please check the terms and conditions');
            return false;
        }
   return( true );
}

