$("document").ready(function(){
	$("#pinglun").click(function(){
		var v=$('#pinglun').html();
		
		if(v=="发表评论"){
			$('#pinglun').html("取消评论");
			$("#pinglun_form").css("display","block");
		}
		else{
			$('#pinglun').html("发表评论");
			$("#pinglun_form").css("display","none");
		}
	});
});