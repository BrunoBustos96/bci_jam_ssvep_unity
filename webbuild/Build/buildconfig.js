var buildUrl = "../webbuild/Build";
export var config = {
  dataUrl: buildUrl + "/webbuild.data",
  loaderUrl: buildUrl + "/webbuild.loader.js",
  frameworkUrl: buildUrl + "/webbuild.framework.js",
  codeUrl: buildUrl + "/webbuild.wasm",
//#if MEMORY_FILENAME
 // memoryUrl: buildUrl + "/{{{ MEMORY_FILENAME }}}",
//#endif
//#if SYMBOLS_FILENAME
//  symbolsUrl: buildUrl + "/{{{ SYMBOLS_FILENAME }}}",
//#endif
  streamingAssetsUrl: "StreamingAssets",
  companyName: "{{{ COMPANY_NAME }}}",
  productName: "{{{ PRODUCT_NAME }}}",
  productVersion: "{{{ PRODUCT_VERSION }}}",
};