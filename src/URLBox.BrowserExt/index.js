if (typeof browser === "undefined") {
  var browser = chrome;
}
browser.tabs.query({ active: true, currentWindow: true }, function (tabs) {
  browser.tabs.get(tabs[0].id, function (tab) {
    console.log("title:"+tab.title);
    setCookie("name", tab.title, 1);
    setCookie("url", tab.url, 1);
  });
});
function setCookie(cname, cvalue, exdays) {
  var d = new Date();
  d.setTime(d.getTime() + exdays * 24 * 60 * 60 * 1000);
  var expires = "expires=" + d.toGMTString();
  document.cookie = cname + "=" + cvalue + "; " + expires;
}
