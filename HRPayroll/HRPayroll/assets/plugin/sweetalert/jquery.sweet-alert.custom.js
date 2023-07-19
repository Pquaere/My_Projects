!function($) {
    "use strict";

    var SweetAlert = function() {};

    //examples 
    SweetAlert.prototype.init = function() {
		
		$('.inactive-id').click(function(){
			swal({   
				title: "Are you sure?",   
				text: "You want to inactive this center!",   
				type: "warning",   
				showCancelButton: true,   
				confirmButtonColor: "#DD6B55",   
				confirmButtonText: "Inactive",   
				closeOnConfirm: false 
			}, function(){   
				swal("Inactive!", "The center is inactive succesfully.", "success"); 
			});
		});
		
		$('.not-approve-id').click(function(){
			swal({   
				title: "Are you sure?",   
				text: "You want to not approve this center!",   
				type: "warning",   
				showCancelButton: true,   
				confirmButtonColor: "#DD6B55",   
				confirmButtonText: "Not Approve",   
				closeOnConfirm: false 
			}, function(){   
				swal("Not Approve!", "The center is not approved succesfully.", "success"); 
			});
		});
		
		$('.delete-id').click(function(){
			swal({   
				title: "Are you sure?",   
				text: "You want to delete this center!",   
				type: "warning",   
				showCancelButton: true,   
				confirmButtonColor: "#DD6B55",   
				confirmButtonText: "Delete",   
				closeOnConfirm: false 
			}, function(){   
				swal("Delete!", "The center is deleted succesfully.", "success"); 
			});
		});

    },
    //init
    $.SweetAlert = new SweetAlert, $.SweetAlert.Constructor = SweetAlert
}(window.jQuery),

//initializing 
function($) {
    "use strict";
    $.SweetAlert.init()
}(window.jQuery);