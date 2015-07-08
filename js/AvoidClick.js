// window の Load イベントを取得する。
window.onload = window_Load;
    
function window_Load() {
  var i;
  
  // 全リンクのクリックイベントを submittableObject_Click で取得する。
  for (i = 0; i < document.links.length; i ++) {
    var item = document.links[i]
    Object.Aspect.around(item, "onclick", checkLoading);
  }
  
  // 全ボタンのクリックイベントを submittableObject_Click で取得する。
  for (i = 0; i < document.forms[0].elements.length; i ++) {
    var item = document.forms[0].elements[i]
    if (item.type == "button" ||
      item.type == "submit" ||
      item.type == "reset") {
      Object.Aspect.around(item, "onclick", checkLoading);
      
    }
  }
  
  return true;
}

//2度押し抑止アスペクト
var checkLoading = function(invocation) {
  if (isDocumentLoading()) {
    alert("処理中です…");
    return false;
  }
  
  return invocation.proceed();
}

//画面描画が終わったかどうか
function isDocumentLoading() {
  return (document.readyState != null &&
          document.readyState != "complete");
}

//アスペクト用
Object.Aspect = {
  _around: function(target, methodName, aspect) {
    var method = target[methodName];
    target[methodName] = function() {
      var invocation = {
        "target" : this,
        "method" : method,
        "methodName" : methodName,
        "arguments" : arguments,
        "proceed" : function() {
          if (!method) {
            return true;
          }
          return method.apply(target, this.arguments);
        }
      };
      return aspect.apply(null, [invocation]);
    };
  },
  around: function(target, methodName, aspect) {
    this._around(target, methodName, aspect);
  }
}
