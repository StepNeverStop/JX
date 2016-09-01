$(document).ready(function(){

	$('input[type=checkbox]').click(function() {
    	$("input[name='type']").attr('disabled', true);
  		if ($("input[name='type']:checked").length >= 3) {
    		$("input[name='type']:checked").attr('disabled', false);
   		} else 
		{
    		$("input[name='type']").attr('disabled', false);
   		}
  	});
});