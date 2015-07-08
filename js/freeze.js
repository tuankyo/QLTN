function FreezeScreen(msg) {
      scroll(0,0);
      var outerPane = document.getElementById('FreezePane');
      var innerPane = document.getElementById('InnerFreezePane');
      if (outerPane) outerPane.className = 'FreezePaneOn';
      if (innerPane) innerPane.innerHTML = msg;
}
