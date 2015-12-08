<!DOCTYPE html>
<!-- saved from url=(0063)http://www.oxxostudio.tw/demo/201509/web-speech-api-demo02.html -->
<html lang="en"><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
  <meta charset="UTF-8">
  <meta name="author" content="oxxo.studio">
  <meta name="copyright" content="oxxo.studio">
  <title>Google 語音辨識 API - demo2</title>
</head>

<body> <h4>辨識的文字會顯示在下方：</h4><h4>&nbsp;</h4><h1 id="show"></h1> 
<script src="https://code.jquery.com/jquery-2.1.4.min.js">
</script> 
<script>var show = $('#show');
console.log(show);
    var recognition = new webkitSpeechRecognition();

    recognition.continuous=true;
    recognition.interimResults=true;
    recognition.lang="cmn-Hant-TW";

    recognition.onstart=function(){
    
    };
    recognition.onend=function(){
     
    };

    recognition.onresult=function(event){
      var i = event.resultIndex;
      var j = event.results[i].length-1;
      show.innerHTML = event.results[i][j].transcript;
 var data = show.innerHTML;

      var path ="https://docs.google.com/forms/d/1nggbzLBGr7itmC7Ug4kgo3BtBe6hPIgst72JsMytjbo/formResponse?entry.1199459699="+data+"&submit=Submit";

      $.getScript(path);

    };

    recognition.start();
</script> </body></html>
