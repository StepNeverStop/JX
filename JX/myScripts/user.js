$("document").ready(function(){
	var change=1;
	$("#change_nickname").click(function(){
		var v=$("#change_nickname").html();
		if(v=="修改昵称"){
			$("#change_nickname").html("取消");
			$("#change_form").css("display","block");
		}
		else{
			$("#change_nickname").html("修改昵称");
			$("#change_form").css("display","none");
		}
	});
	$("#userbook_li").click(function(){
		if(change==1){
			change=0;
			$("#userbook").css("display","block");
		}
		else{
			change=1;
			$("#userbook").css("display","none");
		}
	});
})