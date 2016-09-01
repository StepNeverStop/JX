$(document).ready(function(){
	$('#username').focusin(function (){
		$('#username').css('border' ,'1px solid #D8D8D8');
    	$('#register-tip1').css('visibility','hidden');
	})
	$('#username').focusout(function (){ 
		if($('#username').val()==""){
			$('#username').css('border' ,'1px solid red');
			$('#register-tip1').css('visibility','visible');
		}
	})
	
	$('#password').focusin(function (){
		$('#password').css('border' ,'1px solid #D8D8D8');
		$('#register-tip2').css('visibility','hidden');
	})
	$('#password').focusout(function (){
		if($('#password').val()==""){
			$('#password').css('border' ,'1px solid red');
			$('#register-tip2').css('visibility','visible');
		}
	})
	
	$('#spassword').focusin(function (){
		$('#spassword').css('border' ,'1px solid #D8D8D8');
		$('#register-tip3').css('visibility','hidden');
	})
	$('#spassword').focusout(function (){
		if($('#spassword').val()==""){
			$('#spassword').css('border' ,'1px solid red');
			$('#register-tip3').css('visibility','visible');
		}
		if($('#spassword').val()!=""&&$('#spassword').val()!=""&&$('#password').val()!=$('#spassword').val()){
			$('#register-tip3').html("两次输入的密码不一致！");
			$('#register-tip3').css('visibility','visible');
		}
	})
});