(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["1f55"],{"1f55":function(t,e,a){"use strict";a.r(e);var s=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"checkout-wrap"},[a("page-title-bar"),a("v-container",{attrs:{fluid:"","pt-0":""}},[a("app-card",{attrs:{fullBlock:!0}},[a("v-layout",{attrs:{row:"",wrap:""}},[a("v-flex",{staticClass:"col-height-auto",attrs:{xs12:"",sm12:"",xl8:"",lg6:"",md6:""}},[a("h2",{staticClass:"px-3 py-4 mb-0"},[t._v(t._s(t.$t("message.billingDetails")))]),a("div",[a("v-layout",{attrs:{row:"",wrap:""}},[a("v-flex",{attrs:{xs12:"",sm6:"",md6:""}},[a("v-text-field",{attrs:{"prepend-icon":"perm_identity",label:"First name",required:""}})],1),a("v-flex",{attrs:{xs12:"",sm6:"",md6:""}},[a("v-text-field",{attrs:{"prepend-icon":"perm_identity",label:"Last name",required:""}})],1)],1),a("v-layout",{attrs:{row:"",wrap:""}},[a("v-flex",{attrs:{xs12:"",sm6:"",md6:""}},[a("v-text-field",{attrs:{"prepend-icon":"mail",label:"Email",required:""}})],1),a("v-flex",{attrs:{xs12:"",sm6:"",md6:""}},[a("v-text-field",{attrs:{"prepend-icon":"phone",label:"Mobile No",required:""}})],1)],1),a("v-layout",{attrs:{row:"",wrap:""}},[a("v-flex",{attrs:{xs12:"",md12:"",sm12:""}},[a("v-text-field",{attrs:{"prepend-icon":"home",label:"Address 1",required:""}})],1),a("v-flex",{attrs:{xs12:"",md12:"",sm12:""}},[a("v-text-field",{attrs:{"prepend-icon":"home",label:"Address 2"}})],1)],1),a("v-layout",{attrs:{row:"",wrap:""}},[a("v-flex",{attrs:{xs12:"",sm4:"",md4:""}},[a("v-autocomplete",{attrs:{items:["Australia","Argentina","China","India","Japan","Spain","United States","United Kingdom","Germany"],label:"Country","prepend-icon":"public"},model:{value:t.selectCountry,callback:function(e){t.selectCountry=e},expression:"selectCountry"}})],1),a("v-flex",{attrs:{xs12:"",sm4:"",md4:""}},[a("v-text-field",{attrs:{"prepend-icon":"location_city",label:"State"}})],1),a("v-flex",{attrs:{xs12:"",sm4:"",md4:""}},[a("v-text-field",{attrs:{"prepend-icon":"domain",label:"City"}})],1)],1),a("v-layout",{attrs:{row:"",wrap:""}},[a("v-flex",{staticClass:"col-height-auto",attrs:{xs12:"",sm12:"",md12:"",xl12:"",lg12:"","mb-4":""}},[a("v-checkbox",{attrs:{label:"Shipping address is the same as billing address.",value:""},model:{value:t.addressCheck,callback:function(e){t.addressCheck=e},expression:"addressCheck"}}),a("span",{staticClass:"error--text fs-12 d-block"},[t._v("All fields marked with an asterisk (*) are required")])],1)],1)],1)]),a("v-flex",{attrs:{xs12:"",sm12:"",xl4:"",lg6:"",md6:"","border-left-1":""}},[a("div",{staticClass:"py-4 px-3"},[a("v-data-table",{attrs:{headers:t.headers,items:t.cart,"hide-actions":""},scopedSlots:t._u([{key:"items",fn:function(e){return[a("td",{staticClass:"d-custom-flex align-items-center justify-center product-img"},[a("img",{staticClass:"img-responsive",attrs:{src:e.item.productImg,height:"63",width:"63"}})]),a("td",[t._v(t._s(e.item.name))]),a("td",{staticClass:"text-center"},[t._v(t._s(e.item.quantity))]),a("td",{staticClass:"text-center"},[t._v("$ "+t._s(e.item.total))])]}}])}),a("div",{staticClass:"d-custom-flex justify-space-between pa-4"},[a("h4",{staticClass:"mb-0"},[t._v(t._s(t.$t("message.total")))]),a("h4",{staticClass:"mb-0"},[t._v("$ "+t._s(t.getTotalPrice))])]),a("span",{staticClass:"text-xs-right d-block"},[a("v-btn",{attrs:{color:"primary"}},[t._v(t._s(t.$t("message.placeOrder")))])],1)],1)])],1)],1)],1)],1)},r=[],l=(a("ac4d"),a("8a81"),a("ac6a"),a("c93e")),i=a("2f62"),n={data:function(){return{selectCountry:["United Kingdom"],addressCheck:[],headers:[{text:"Product",sortable:!1,align:"center"},{text:"",sortable:!1},{text:"Quantity",sortable:!1,align:"center"},{text:"Total",sortable:!1,align:"center"}]}},computed:Object(l["a"])({},Object(i["b"])(["cart"]),{getTotalPrice:function(){var t=0;if(this.cart.length>0){var e=!0,a=!1,s=void 0;try{for(var r,l=this.cart[Symbol.iterator]();!(e=(r=l.next()).done);e=!0){var i=r.value;t+=i.total}}catch(t){a=!0,s=t}finally{try{e||null==l.return||l.return()}finally{if(a)throw s}}return t.toFixed(2)}return t}})},d=n,o=a("2877"),c=Object(o["a"])(d,s,r,!1,null,null,null);c.options.__file="Checkout.vue";e["default"]=c.exports}}]);
//# sourceMappingURL=1f55.f03268fa.js.map