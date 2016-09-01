$("document").ready(function(){
	$("#title_dh").click(function(){
		var mes=$('#title_dh').html();
		if(mes=="&gt;&gt;"){
			$('#title_dh').html("&lt;&lt;");
			$("#title_dh_content").css("visibility","hidden");
		}
		else{
			$("#title_dh").html("&gt;&gt;");
			$("#title_dh_content").css("visibility","visible");
		}
	});
});