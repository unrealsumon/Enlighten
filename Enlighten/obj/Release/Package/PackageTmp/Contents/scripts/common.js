function PopupMsg(msg, type) {
    Swal({
        type: type,
        title: type.toUpperCase() + ' !',
        text: msg,

    });
}



function  PopupDelete(){
    var global;
     Swal({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
     },global).then( function  (result) {
         if (result.value) {
             
         }
       
     },global)
   
}