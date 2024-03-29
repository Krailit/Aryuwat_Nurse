! function (t, e) {
    "object" == typeof exports && "object" == typeof module ? module.exports = e() : "function" == typeof define && define.amd ? define([], e) : "object" == typeof exports ? exports.Vuetable = e() : t.Vuetable = e()
}(this, function () {
    return function (t) {
        function e(i) {
            if (n[i]) return n[i].exports;
            var a = n[i] = {
                i: i,
                l: !1,
                exports: {}
            };
            return t[i].call(a.exports, a, a.exports, e), a.l = !0, a.exports
        }
        var n = {};
        return e.m = t, e.c = n, e.i = function (t) {
            return t
        }, e.d = function (t, n, i) {
            e.o(t, n) || Object.defineProperty(t, n, {
                configurable: !1,
                enumerable: !0,
                get: i
            })
        }, e.n = function (t) {
            var n = t && t.__esModule ? function () {
                return t.default
            } : function () {
                return t
            };
            return e.d(n, "a", n), n
        }, e.o = function (t, e) {
            return Object.prototype.hasOwnProperty.call(t, e)
        }, e.p = "/", e(e.s = 40)
    }([function (t, e, n) {
        "use strict";

        function i(t) {
            return "[object Array]" === x.call(t)
        }

        function a(t) {
            return "[object ArrayBuffer]" === x.call(t)
        }

        function r(t) {
            return "undefined" != typeof FormData && t instanceof FormData
        }

        function o(t) {
            return "undefined" != typeof ArrayBuffer && ArrayBuffer.isView ? ArrayBuffer.isView(t) : t && t.buffer && t.buffer instanceof ArrayBuffer
        }

        function s(t) {
            return "string" == typeof t
        }

        function l(t) {
            return "number" == typeof t
        }

        function c(t) {
            return void 0 === t
        }

        function u(t) {
            return null !== t && "object" == typeof t
        }

        function d(t) {
            return "[object Date]" === x.call(t)
        }

        function f(t) {
            return "[object File]" === x.call(t)
        }

        function h(t) {
            return "[object Blob]" === x.call(t)
        }

        function p(t) {
            return "[object Function]" === x.call(t)
        }

        function m(t) {
            return u(t) && p(t.pipe)
        }

        function v(t) {
            return "undefined" != typeof URLSearchParams && t instanceof URLSearchParams
        }

        function g(t) {
            return t.replace(/^\s*/, "").replace(/\s*$/, "")
        }

        function b() {
            return "undefined" != typeof window && "undefined" != typeof document && "function" == typeof document.createElement
        }

        function y(t, e) {
            if (null !== t && void 0 !== t)
                if ("object" == typeof t || i(t) || (t = [t]), i(t))
                    for (var n = 0, a = t.length; n < a; n++) e.call(null, t[n], n, t);
                else
                    for (var r in t) Object.prototype.hasOwnProperty.call(t, r) && e.call(null, t[r], r, t)
        }

        function w() {
            function t(t, n) {
                "object" == typeof e[n] && "object" == typeof t ? e[n] = w(e[n], t) : e[n] = t
            }
            for (var e = {}, n = 0, i = arguments.length; n < i; n++) y(arguments[n], t);
            return e
        }

        function _(t, e, n) {
            return y(e, function (e, i) {
                t[i] = n && "function" == typeof e ? C(e, n) : e
            }), t
        }
        var C = n(9),
            x = Object.prototype.toString;
        t.exports = {
            isArray: i,
            isArrayBuffer: a,
            isFormData: r,
            isArrayBufferView: o,
            isString: s,
            isNumber: l,
            isObject: u,
            isUndefined: c,
            isDate: d,
            isFile: f,
            isBlob: h,
            isFunction: p,
            isStream: m,
            isURLSearchParams: v,
            isStandardBrowserEnv: b,
            forEach: y,
            merge: w,
            extend: _,
            trim: g
        }
    }, function (t, e) {
        t.exports = function (t, e, n, i, a) {
            var r, o = t = t || {},
                s = typeof t.default;
            "object" !== s && "function" !== s || (r = t, o = t.default);
            var l = "function" == typeof o ? o.options : o;
            e && (l.render = e.render, l.staticRenderFns = e.staticRenderFns), i && (l._scopeId = i);
            var c;
            if (a ? (c = function (t) {
                t = t || this.$vnode && this.$vnode.ssrContext || this.parent && this.parent.$vnode && this.parent.$vnode.ssrContext, t || "undefined" == typeof __VUE_SSR_CONTEXT__ || (t = __VUE_SSR_CONTEXT__), n && n.call(this, t), t && t._registeredComponents && t._registeredComponents.add(a)
            }, l._ssrRegister = c) : n && (c = n), c) {
                var u = l.functional,
                    d = u ? l.render : l.beforeCreate;
                u ? l.render = function (t, e) {
                    return c.call(e), d(t, e)
                } : l.beforeCreate = d ? [].concat(d, c) : [c]
            }
            return {
                esModule: r,
                exports: o,
                options: l
            }
        }
    }, function (t, e, n) {
        var i = n(1)(n(39), null, null, null, null);
        t.exports = i.exports
    }, function (t, e, n) {
        "use strict";
        (function (e) {
            function i(t, e) {
                !a.isUndefined(t) && a.isUndefined(t["Content-Type"]) && (t["Content-Type"] = e)
            }
            var a = n(0),
                r = n(31),
                o = /^\)\]\}',?\n/,
                s = {
                    "Content-Type": "application/x-www-form-urlencoded"
                },
                l = {
                    adapter: function () {
                        var t;
                        return "undefined" != typeof XMLHttpRequest ? t = n(5) : void 0 !== e && (t = n(5)), t
                    }(),
                    transformRequest: [function (t, e) {
                        return r(e, "Content-Type"), a.isFormData(t) || a.isArrayBuffer(t) || a.isStream(t) || a.isFile(t) || a.isBlob(t) ? t : a.isArrayBufferView(t) ? t.buffer : a.isURLSearchParams(t) ? (i(e, "application/x-www-form-urlencoded;charset=utf-8"), t.toString()) : a.isObject(t) ? (i(e, "application/json;charset=utf-8"), JSON.stringify(t)) : t
                    }],
                    transformResponse: [function (t) {
                        if ("string" == typeof t) {
                            t = t.replace(o, "");
                            try {
                                t = JSON.parse(t)
                            } catch (t) { }
                        }
                        return t
                    }],
                    timeout: 0,
                    xsrfCookieName: "XSRF-TOKEN",
                    xsrfHeaderName: "X-XSRF-TOKEN",
                    maxContentLength: -1,
                    validateStatus: function (t) {
                        return t >= 200 && t < 300
                    }
                };
            l.headers = {
                common: {
                    Accept: "application/json, text/plain, */*"
                }
            }, a.forEach(["delete", "get", "head"], function (t) {
                l.headers[t] = {}
            }), a.forEach(["post", "put", "patch"], function (t) {
                l.headers[t] = a.merge(s)
            }), t.exports = l
        }).call(e, n(10))
    }, function (t, e, n) {
        var i = n(1)(n(38), null, null, null, null);
        t.exports = i.exports
    }, function (t, e, n) {
        "use strict";
        var i = n(0),
            a = n(23),
            r = n(26),
            o = n(32),
            s = n(30),
            l = n(8),
            c = "undefined" != typeof window && window.btoa && window.btoa.bind(window) || n(25);
        t.exports = function (t) {
            return new Promise(function (e, u) {
                var d = t.data,
                    f = t.headers;
                i.isFormData(d) && delete f["Content-Type"];
                var h = new XMLHttpRequest,
                    p = "onreadystatechange",
                    m = !1;
                if ("undefined" == typeof window || !window.XDomainRequest || "withCredentials" in h || s(t.url) || (h = new window.XDomainRequest, p = "onload", m = !0, h.onprogress = function () { }, h.ontimeout = function () { }), t.auth) {
                    var v = t.auth.username || "",
                        g = t.auth.password || "";
                    f.Authorization = "Basic " + c(v + ":" + g)
                }
                if (h.open(t.method.toUpperCase(), r(t.url, t.params, t.paramsSerializer), !0), h.timeout = t.timeout, h[p] = function () {
                    if (h && (4 === h.readyState || m) && (0 !== h.status || h.responseURL && 0 === h.responseURL.indexOf("file:"))) {
                        var n = "getAllResponseHeaders" in h ? o(h.getAllResponseHeaders()) : null,
                            i = t.responseType && "text" !== t.responseType ? h.response : h.responseText,
                            r = {
                                data: i,
                                status: 1223 === h.status ? 204 : h.status,
                                statusText: 1223 === h.status ? "No Content" : h.statusText,
                                headers: n,
                                config: t,
                                request: h
                            };
                        a(e, u, r), h = null
                    }
                }, h.onerror = function () {
                    u(l("Network Error", t)), h = null
                }, h.ontimeout = function () {
                    u(l("timeout of " + t.timeout + "ms exceeded", t, "ECONNABORTED")), h = null
                }, i.isStandardBrowserEnv()) {
                    var b = n(28),
                        y = (t.withCredentials || s(t.url)) && t.xsrfCookieName ? b.read(t.xsrfCookieName) : void 0;
                    y && (f[t.xsrfHeaderName] = y)
                }
                if ("setRequestHeader" in h && i.forEach(f, function (t, e) {
                    void 0 === d && "content-type" === e.toLowerCase() ? delete f[e] : h.setRequestHeader(e, t)
                }), t.withCredentials && (h.withCredentials = !0), t.responseType) try {
                    h.responseType = t.responseType
                } catch (t) {
                    if ("json" !== h.responseType) throw t
                }
                "function" == typeof t.onDownloadProgress && h.addEventListener("progress", t.onDownloadProgress), "function" == typeof t.onUploadProgress && h.upload && h.upload.addEventListener("progress", t.onUploadProgress), t.cancelToken && t.cancelToken.promise.then(function (t) {
                    h && (h.abort(), u(t), h = null)
                }), void 0 === d && (d = null), h.send(d)
            })
        }
    }, function (t, e, n) {
        "use strict";

        function i(t) {
            this.message = t
        }
        i.prototype.toString = function () {
            return "Cancel" + (this.message ? ": " + this.message : "")
        }, i.prototype.__CANCEL__ = !0, t.exports = i
    }, function (t, e, n) {
        "use strict";
        t.exports = function (t) {
            return !(!t || !t.__CANCEL__)
        }
    }, function (t, e, n) {
        "use strict";
        var i = n(22);
        t.exports = function (t, e, n, a) {
            var r = new Error(t);
            return i(r, e, n, a)
        }
    }, function (t, e, n) {
        "use strict";
        t.exports = function (t, e) {
            return function () {
                for (var n = new Array(arguments.length), i = 0; i < n.length; i++) n[i] = arguments[i];
                return t.apply(e, n)
            }
        }
    }, function (t, e) {
        function n() {
            throw new Error("setTimeout has not been defined")
        }

        function i() {
            throw new Error("clearTimeout has not been defined")
        }

        function a(t) {
            if (u === setTimeout) return setTimeout(t, 0);
            if ((u === n || !u) && setTimeout) return u = setTimeout, setTimeout(t, 0);
            try {
                return u(t, 0)
            } catch (e) {
                try {
                    return u.call(null, t, 0)
                } catch (e) {
                    return u.call(this, t, 0)
                }
            }
        }

        function r(t) {
            if (d === clearTimeout) return clearTimeout(t);
            if ((d === i || !d) && clearTimeout) return d = clearTimeout, clearTimeout(t);
            try {
                return d(t)
            } catch (e) {
                try {
                    return d.call(null, t)
                } catch (e) {
                    return d.call(this, t)
                }
            }
        }

        function o() {
            m && h && (m = !1, h.length ? p = h.concat(p) : v = -1, p.length && s())
        }

        function s() {
            if (!m) {
                var t = a(o);
                m = !0;
                for (var e = p.length; e;) {
                    for (h = p, p = []; ++v < e;) h && h[v].run();
                    v = -1, e = p.length
                }
                h = null, m = !1, r(t)
            }
        }

        function l(t, e) {
            this.fun = t, this.array = e
        }

        function c() { }
        var u, d, f = t.exports = {};
        ! function () {
            try {
                u = "function" == typeof setTimeout ? setTimeout : n
            } catch (t) {
                u = n
            }
            try {
                d = "function" == typeof clearTimeout ? clearTimeout : i
            } catch (t) {
                d = i
            }
        }();
        var h, p = [],
            m = !1,
            v = -1;
        f.nextTick = function (t) {
            var e = new Array(arguments.length - 1);
            if (arguments.length > 1)
                for (var n = 1; n < arguments.length; n++) e[n - 1] = arguments[n];
            p.push(new l(t, e)), 1 !== p.length || m || a(s)
        }, l.prototype.run = function () {
            this.fun.apply(null, this.array)
        }, f.title = "browser", f.browser = !0, f.env = {}, f.argv = [], f.version = "", f.versions = {}, f.on = c, f.addListener = c, f.once = c, f.off = c, f.removeListener = c, f.removeAllListeners = c, f.emit = c, f.prependListener = c, f.prependOnceListener = c, f.listeners = function (t) {
            return []
        }, f.binding = function (t) {
            throw new Error("process.binding is not supported")
        }, f.cwd = function () {
            return "/"
        }, f.chdir = function (t) {
            throw new Error("process.chdir is not supported")
        }, f.umask = function () {
            return 0
        }
    }, function (t, e, n) {
        (function (e) {
            ! function (n) {
                function i() { }

                function a(t, e) {
                    return function () {
                        t.apply(e, arguments)
                    }
                }

                function r(t) {
                    if ("object" != typeof this) throw new TypeError("Promises must be constructed via new");
                    if ("function" != typeof t) throw new TypeError("not a function");
                    this._state = 0, this._handled = !1, this._value = void 0, this._deferreds = [], d(t, this)
                }

                function o(t, e) {
                    for (; 3 === t._state;) t = t._value;
                    if (0 === t._state) return void t._deferreds.push(e);
                    t._handled = !0, r._immediateFn(function () {
                        var n = 1 === t._state ? e.onFulfilled : e.onRejected;
                        if (null === n) return void (1 === t._state ? s : l)(e.promise, t._value);
                        var i;
                        try {
                            i = n(t._value)
                        } catch (t) {
                            return void l(e.promise, t)
                        }
                        s(e.promise, i)
                    })
                }

                function s(t, e) {
                    try {
                        if (e === t) throw new TypeError("A promise cannot be resolved with itself.");
                        if (e && ("object" == typeof e || "function" == typeof e)) {
                            var n = e.then;
                            if (e instanceof r) return t._state = 3, t._value = e, void c(t);
                            if ("function" == typeof n) return void d(a(n, e), t)
                        }
                        t._state = 1, t._value = e, c(t)
                    } catch (e) {
                        l(t, e)
                    }
                }

                function l(t, e) {
                    t._state = 2, t._value = e, c(t)
                }

                function c(t) {
                    2 === t._state && 0 === t._deferreds.length && r._immediateFn(function () {
                        t._handled || r._unhandledRejectionFn(t._value)
                    });
                    for (var e = 0, n = t._deferreds.length; e < n; e++) o(t, t._deferreds[e]);
                    t._deferreds = null
                }

                function u(t, e, n) {
                    this.onFulfilled = "function" == typeof t ? t : null, this.onRejected = "function" == typeof e ? e : null, this.promise = n
                }

                function d(t, e) {
                    var n = !1;
                    try {
                        t(function (t) {
                            n || (n = !0, s(e, t))
                        }, function (t) {
                            n || (n = !0, l(e, t))
                        })
                    } catch (t) {
                        if (n) return;
                        n = !0, l(e, t)
                    }
                }
                var f = setTimeout;
                r.prototype.catch = function (t) {
                    return this.then(null, t)
                }, r.prototype.then = function (t, e) {
                    var n = new this.constructor(i);
                    return o(this, new u(t, e, n)), n
                }, r.all = function (t) {
                    var e = Array.prototype.slice.call(t);
                    return new r(function (t, n) {
                        function i(r, o) {
                            try {
                                if (o && ("object" == typeof o || "function" == typeof o)) {
                                    var s = o.then;
                                    if ("function" == typeof s) return void s.call(o, function (t) {
                                        i(r, t)
                                    }, n)
                                }
                                e[r] = o, 0 == --a && t(e)
                            } catch (t) {
                                n(t)
                            }
                        }
                        if (0 === e.length) return t([]);
                        for (var a = e.length, r = 0; r < e.length; r++) i(r, e[r])
                    })
                }, r.resolve = function (t) {
                    return t && "object" == typeof t && t.constructor === r ? t : new r(function (e) {
                        e(t)
                    })
                }, r.reject = function (t) {
                    return new r(function (e, n) {
                        n(t)
                    })
                }, r.race = function (t) {
                    return new r(function (e, n) {
                        for (var i = 0, a = t.length; i < a; i++) t[i].then(e, n)
                    })
                }, r._immediateFn = "function" == typeof e && function (t) {
                    e(t)
                } || function (t) {
                    f(t, 0)
                }, r._unhandledRejectionFn = function (t) {
                    "undefined" != typeof console && console && console.warn("Possible Unhandled Promise Rejection:", t)
                }, r._setImmediateFn = function (t) {
                    r._immediateFn = t
                }, r._setUnhandledRejectionFn = function (t) {
                    r._unhandledRejectionFn = t
                }, void 0 !== t && t.exports ? t.exports = r : n.Promise || (n.Promise = r)
            }(this)
        }).call(e, n(44).setImmediate)
    }, function (t, e, n) {
        function i(t) {
            n(49)
        }
        var a = n(1)(n(34), n(46), i, "data-v-5cc42bfc", null);
        t.exports = a.exports
    }, function (t, e, n) {
        var i = n(1)(n(35), n(47), null, null, null);
        t.exports = i.exports
    }, function (t, e, n) {
        var i = n(1)(n(36), n(45), null, null, null);
        t.exports = i.exports
    }, function (t, e, n) {
        var i = n(1)(n(37), n(48), null, null, null);
        t.exports = i.exports
    }, function (t, e, n) {
        t.exports = n(17)
    }, function (t, e, n) {
        "use strict";

        function i(t) {
            var e = new o(t),
                n = r(o.prototype.request, e);
            return a.extend(n, o.prototype, e), a.extend(n, e), n
        }
        var a = n(0),
            r = n(9),
            o = n(19),
            s = n(3),
            l = i(s);
        l.Axios = o, l.create = function (t) {
            return i(a.merge(s, t))
        }, l.Cancel = n(6), l.CancelToken = n(18), l.isCancel = n(7), l.all = function (t) {
            return Promise.all(t)
        }, l.spread = n(33), t.exports = l, t.exports.default = l
    }, function (t, e, n) {
        "use strict";

        function i(t) {
            if ("function" != typeof t) throw new TypeError("executor must be a function.");
            var e;
            this.promise = new Promise(function (t) {
                e = t
            });
            var n = this;
            t(function (t) {
                n.reason || (n.reason = new a(t), e(n.reason))
            })
        }
        var a = n(6);
        i.prototype.throwIfRequested = function () {
            if (this.reason) throw this.reason
        }, i.source = function () {
            var t;
            return {
                token: new i(function (e) {
                    t = e
                }),
                cancel: t
            }
        }, t.exports = i
    }, function (t, e, n) {
        "use strict";

        function i(t) {
            this.defaults = t, this.interceptors = {
                request: new o,
                response: new o
            }
        }
        var a = n(3),
            r = n(0),
            o = n(20),
            s = n(21),
            l = n(29),
            c = n(27);
        i.prototype.request = function (t) {
            "string" == typeof t && (t = r.merge({
                url: arguments[0]
            }, arguments[1])), t = r.merge(a, this.defaults, {
                method: "get"
            }, t), t.baseURL && !l(t.url) && (t.url = c(t.baseURL, t.url));
            var e = [s, void 0],
                n = Promise.resolve(t);
            for (this.interceptors.request.forEach(function (t) {
                e.unshift(t.fulfilled, t.rejected)
            }), this.interceptors.response.forEach(function (t) {
                e.push(t.fulfilled, t.rejected)
            }); e.length;) n = n.then(e.shift(), e.shift());
            return n
        }, r.forEach(["delete", "get", "head"], function (t) {
            i.prototype[t] = function (e, n) {
                return this.request(r.merge(n || {}, {
                    method: t,
                    url: e
                }))
            }
        }), r.forEach(["post", "put", "patch"], function (t) {
            i.prototype[t] = function (e, n, i) {
                return this.request(r.merge(i || {}, {
                    method: t,
                    url: e,
                    data: n
                }))
            }
        }), t.exports = i
    }, function (t, e, n) {
        "use strict";

        function i() {
            this.handlers = []
        }
        var a = n(0);
        i.prototype.use = function (t, e) {
            return this.handlers.push({
                fulfilled: t,
                rejected: e
            }), this.handlers.length - 1
        }, i.prototype.eject = function (t) {
            this.handlers[t] && (this.handlers[t] = null)
        }, i.prototype.forEach = function (t) {
            a.forEach(this.handlers, function (e) {
                null !== e && t(e)
            })
        }, t.exports = i
    }, function (t, e, n) {
        "use strict";

        function i(t) {
            t.cancelToken && t.cancelToken.throwIfRequested()
        }
        var a = n(0),
            r = n(24),
            o = n(7),
            s = n(3);
        t.exports = function (t) {
            return i(t), t.headers = t.headers || {}, t.data = r(t.data, t.headers, t.transformRequest), t.headers = a.merge(t.headers.common || {}, t.headers[t.method] || {}, t.headers || {}), a.forEach(["delete", "get", "head", "post", "put", "patch", "common"], function (e) {
                delete t.headers[e]
            }), (t.adapter || s.adapter)(t).then(function (e) {
                return i(t), e.data = r(e.data, e.headers, t.transformResponse), e
            }, function (e) {
                return o(e) || (i(t), e && e.response && (e.response.data = r(e.response.data, e.response.headers, t.transformResponse))), Promise.reject(e)
            })
        }
    }, function (t, e, n) {
        "use strict";
        t.exports = function (t, e, n, i) {
            return t.config = e, n && (t.code = n), t.response = i, t
        }
    }, function (t, e, n) {
        "use strict";
        var i = n(8);
        t.exports = function (t, e, n) {
            var a = n.config.validateStatus;
            n.status && a && !a(n.status) ? e(i("Request failed with status code " + n.status, n.config, null, n)) : t(n)
        }
    }, function (t, e, n) {
        "use strict";
        var i = n(0);
        t.exports = function (t, e, n) {
            return i.forEach(n, function (n) {
                t = n(t, e)
            }), t
        }
    }, function (t, e, n) {
        "use strict";

        function i() {
            this.message = "String contains an invalid character"
        }

        function a(t) {
            for (var e, n, a = String(t), o = "", s = 0, l = r; a.charAt(0 | s) || (l = "=", s % 1); o += l.charAt(63 & e >> 8 - s % 1 * 8)) {
                if ((n = a.charCodeAt(s += .75)) > 255) throw new i;
                e = e << 8 | n
            }
            return o
        }
        var r = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
        i.prototype = new Error, i.prototype.code = 5, i.prototype.name = "InvalidCharacterError", t.exports = a
    }, function (t, e, n) {
        "use strict";

        function i(t) {
            return encodeURIComponent(t).replace(/%40/gi, "@").replace(/%3A/gi, ":").replace(/%24/g, "$").replace(/%2C/gi, ",").replace(/%20/g, "+").replace(/%5B/gi, "[").replace(/%5D/gi, "]")
        }
        var a = n(0);
        t.exports = function (t, e, n) {
            if (!e) return t;
            var r;
            if (n) r = n(e);
            else if (a.isURLSearchParams(e)) r = e.toString();
            else {
                var o = [];
                a.forEach(e, function (t, e) {
                    null !== t && void 0 !== t && (a.isArray(t) && (e += "[]"), a.isArray(t) || (t = [t]), a.forEach(t, function (t) {
                        a.isDate(t) ? t = t.toISOString() : a.isObject(t) && (t = JSON.stringify(t)), o.push(i(e) + "=" + i(t))
                    }))
                }), r = o.join("&")
            }
            return r && (t += (-1 === t.indexOf("?") ? "?" : "&") + r), t
        }
    }, function (t, e, n) {
        "use strict";
        t.exports = function (t, e) {
            return t.replace(/\/+$/, "") + "/" + e.replace(/^\/+/, "")
        }
    }, function (t, e, n) {
        "use strict";
        var i = n(0);
        t.exports = i.isStandardBrowserEnv() ? function () {
            return {
                write: function (t, e, n, a, r, o) {
                    var s = [];
                    s.push(t + "=" + encodeURIComponent(e)), i.isNumber(n) && s.push("expires=" + new Date(n).toGMTString()), i.isString(a) && s.push("path=" + a), i.isString(r) && s.push("domain=" + r), !0 === o && s.push("secure"), document.cookie = s.join("; ")
                },
                read: function (t) {
                    var e = document.cookie.match(new RegExp("(^|;\\s*)(" + t + ")=([^;]*)"));
                    return e ? decodeURIComponent(e[3]) : null
                },
                remove: function (t) {
                    this.write(t, "", Date.now() - 864e5)
                }
            }
        }() : function () {
            return {
                write: function () { },
                read: function () {
                    return null
                },
                remove: function () { }
            }
        }()
    }, function (t, e, n) {
        "use strict";
        t.exports = function (t) {
            return /^([a-z][a-z\d\+\-\.]*:)?\/\//i.test(t)
        }
    }, function (t, e, n) {
        "use strict";
        var i = n(0);
        t.exports = i.isStandardBrowserEnv() ? function () {
            function t(t) {
                var e = t;
                return n && (a.setAttribute("href", e), e = a.href), a.setAttribute("href", e), {
                    href: a.href,
                    protocol: a.protocol ? a.protocol.replace(/:$/, "") : "",
                    host: a.host,
                    search: a.search ? a.search.replace(/^\?/, "") : "",
                    hash: a.hash ? a.hash.replace(/^#/, "") : "",
                    hostname: a.hostname,
                    port: a.port,
                    pathname: "/" === a.pathname.charAt(0) ? a.pathname : "/" + a.pathname
                }
            }
            var e, n = /(msie|trident)/i.test(navigator.userAgent),
                a = document.createElement("a");
            return e = t(window.location.href),
                function (n) {
                    var a = i.isString(n) ? t(n) : n;
                    return a.protocol === e.protocol && a.host === e.host
                }
        }() : function () {
            return function () {
                return !0
            }
        }()
    }, function (t, e, n) {
        "use strict";
        var i = n(0);
        t.exports = function (t, e) {
            i.forEach(t, function (n, i) {
                i !== e && i.toUpperCase() === e.toUpperCase() && (t[e] = n, delete t[i])
            })
        }
    }, function (t, e, n) {
        "use strict";
        var i = n(0);
        t.exports = function (t) {
            var e, n, a, r = {};
            return t ? (i.forEach(t.split("\n"), function (t) {
                a = t.indexOf(":"), e = i.trim(t.substr(0, a)).toLowerCase(), n = i.trim(t.substr(a + 1)), e && (r[e] = r[e] ? r[e] + ", " + n : n)
            }), r) : r
        }
    }, function (t, e, n) {
        "use strict";
        t.exports = function (t) {
            return function (e) {
                return t.apply(null, e)
            }
        }
    }, function (t, e, n) {
        "use strict";
        Object.defineProperty(e, "__esModule", {
            value: !0
        });
        var i = n(16),
            a = n.n(i);
        e.default = {
            props: {
                fields: {
                    type: Array,
                    required: !0
                },
                loadOnStart: {
                    type: Boolean,
                    default: !0
                },
                apiUrl: {
                    type: String,
                    default: ""
                },
                httpMethod: {
                    type: String,
                    default: "get",
                    validator: function (t) {
                        return ["get", "post"].indexOf(t) > -1
                    }
                },
                reactiveApiUrl: {
                    type: Boolean,
                    default: !0
                },
                apiMode: {
                    type: Boolean,
                    default: !0
                },
                data: {
                    type: [Array, Object],
                    default: function () {
                        return null
                    }
                },
                dataTotal: {
                    type: Number,
                    default: 0
                },
                dataManager: {
                    type: Function,
                    default: function () {
                        return null
                    }
                },
                dataPath: {
                    type: String,
                    default: "data"
                },
                paginationPath: {
                    type: [String],
                    default: "links.pagination"
                },
                queryParams: {
                    type: Object,
                    default: function () {
                        return {
                            sort: "sort",
                            page: "page",
                            perPage: "per_page"
                        }
                    }
                },
                appendParams: {
                    type: Object,
                    default: function () {
                        return {}
                    }
                },
                httpOptions: {
                    type: Object,
                    default: function () {
                        return {}
                    }
                },
                httpFetch: {
                    type: Function,
                    default: null
                },
                perPage: {
                    type: Number,
                    default: function () {
                        return 10
                    }
                },
                initialPage: {
                    type: Number,
                    default: function () {
                        return 1
                    }
                },
                sortOrder: {
                    type: Array,
                    default: function () {
                        return []
                    }
                },
                multiSort: {
                    type: Boolean,
                    default: function () {
                        return !1
                    }
                },
                tableHeight: {
                    type: String,
                    default: null
                },
                multiSortKey: {
                    type: String,
                    default: "alt"
                },
                rowClassCallback: {
                    type: [String, Function],
                    default: ""
                },
                rowClass: {
                    type: [String, Function],
                    default: ""
                },
                detailRowComponent: {
                    type: String,
                    default: ""
                },
                detailRowTransition: {
                    type: String,
                    default: ""
                },
                trackBy: {
                    type: String,
                    default: "id"
                },
                css: {
                    type: Object,
                    default: function () {
                        return {
                            tableClass: "ui blue selectable celled stackable attached table",
                            loadingClass: "loading",
                            ascendingIcon: "blue chevron up icon",
                            descendingIcon: "blue chevron down icon",
                            ascendingClass: "sorted-asc",
                            descendingClass: "sorted-desc",
                            sortableIcon: "",
                            detailRowClass: "vuetable-detail-row",
                            handleIcon: "grey sidebar icon",
                            tableBodyClass: "vuetable-semantic-no-top vuetable-fixed-layout",
                            tableHeaderClass: "vuetable-fixed-layout"
                        }
                    }
                },
                minRows: {
                    type: Number,
                    default: 0
                },
                silent: {
                    type: Boolean,
                    default: !1
                },
                noDataTemplate: {
                    type: String,
                    default: function () {
                        return "No Data Available"
                    }
                },
                showSortIcons: {
                    type: Boolean,
                    default: !0
                }
            },
            data: function () {
                return {
                    eventPrefix: "vuetable:",
                    tableFields: [],
                    tableData: null,
                    tablePagination: null,
                    currentPage: this.initialPage,
                    selectedTo: [],
                    visibleDetailRows: [],
                    lastScrollPosition: 0,
                    scrollBarWidth: "17px",
                    scrollVisible: !1
                }
            },
            mounted: function () {
                if (this.normalizeFields(), this.normalizeSortOrder(), this.isFixedHeader && (this.scrollBarWidth = this.getScrollBarWidth() + "px"), this.$nextTick(function () {
                    this.fireEvent("initialized", this.tableFields)
                }), this.loadOnStart && this.loadData(), this.isFixedHeader) {
                    var t = this.$el.getElementsByClassName("vuetable-body-wrapper")[0];
                    null != t && t.addEventListener("scroll", this.handleScroll)
                }
            },
            destroyed: function () {
                var t = this.$el.getElementsByClassName("vuetable-body-wrapper")[0];
                null != t && t.removeEventListener("scroll", this.handleScroll)
            },
            computed: {
                useDetailRow: function () {
                    return this.tableData && this.tableData[0] && "" !== this.detailRowComponent && void 0 === this.tableData[0][this.trackBy] ? (this.warn("You need to define unique row identifier in order for detail-row feature to work. Use `track-by` prop to define one!"), !1) : "" !== this.detailRowComponent
                },
                countVisibleFields: function () {
                    return this.tableFields.filter(function (t) {
                        return t.visible
                    }).length
                },
                countTableData: function () {
                    return null === this.tableData ? 0 : this.tableData.length
                },
                displayEmptyDataRow: function () {
                    return 0 === this.countTableData && this.noDataTemplate.length > 0
                },
                lessThanMinRows: function () {
                    return null === this.tableData || 0 === this.tableData.length || this.tableData.length < this.minRows
                },
                blankRows: function () {
                    return null === this.tableData || 0 === this.tableData.length ? this.minRows : this.tableData.length >= this.minRows ? 0 : this.minRows - this.tableData.length
                },
                isApiMode: function () {
                    return this.apiMode
                },
                isDataMode: function () {
                    return !this.apiMode
                },
                isFixedHeader: function () {
                    return null != this.tableHeight
                }
            },
            methods: {
                getScrollBarWidth: function () {
                    var t = document.createElement("div"),
                        e = document.createElement("div");
                    t.style.visibility = "hidden", t.style.width = "100px", e.style.width = "100%", t.appendChild(e), document.body.appendChild(t);
                    var n = t.offsetWidth;
                    t.style.overflow = "scroll";
                    var i = e.offsetWidth;
                    return document.body.removeChild(t), n - i
                },
                handleScroll: function (t) {
                    var e = t.currentTarget.scrollLeft;
                    if (e != this.lastScrollPosition) {
                        var n = this.$el.getElementsByClassName("vuetable-head-wrapper")[0];
                        null != n && (n.scrollLeft = e), this.lastScrollPosition = e
                    }
                },
                normalizeFields: function () {
                    if (void 0 === this.fields) return void this.warn('You need to provide "fields" prop.');
                    this.tableFields = [];
                    var t = this,
                        e = void 0;
                    this.fields.forEach(function (n, i) {
                        e = "string" == typeof n ? {
                            name: n,
                            title: t.setTitle(n),
                            titleClass: "",
                            dataClass: "",
                            callback: null,
                            visible: !0
                        } : {
                                name: n.name,
                                width: n.width,
                                title: void 0 === n.title ? t.setTitle(n.name) : n.title,
                                sortField: n.sortField,
                                titleClass: void 0 === n.titleClass ? "" : n.titleClass,
                                dataClass: void 0 === n.dataClass ? "" : n.dataClass,
                                callback: void 0 === n.callback ? "" : n.callback,
                                visible: void 0 === n.visible || n.visible
                            }, t.tableFields.push(e)
                    })
                },
                setData: function (t) {
                    if (this.apiMode = !1, Array.isArray(t)) return void (this.tableData = t);
                    this.fireEvent("loading"), this.tableData = this.getObjectValue(t, this.dataPath, null), this.tablePagination = this.getObjectValue(t, this.paginationPath, null), this.$nextTick(function () {
                        this.fireEvent("pagination-data", this.tablePagination), this.fireEvent("loaded")
                    })
                },
                setTitle: function (t) {
                    return this.isSpecialField(t) ? "" : this.titleCase(t)
                },
                getTitle: function (t) {
                    return "function" == typeof t.title ? t.title() : void 0 === t.title ? t.name.replace(".", " ") : t.title
                },
                renderTitle: function (t) {
                    var e = this.getTitle(t);
                    if (e.length > 0 && this.isInCurrentSortGroup(t) || this.hasSortableIcon(t)) {
                        var n = "opacity:" + this.sortIconOpacity(t) + ";position:relative;float:right";
                        return e + " " + this.renderIconTag(["sort-icon", this.sortIcon(t)], 'style="' + n + '"')
                    }
                    return e
                },
                renderSequence: function (t) {
                    return this.tablePagination ? this.tablePagination.from + t : t
                },
                renderNormalField: function (t, e) {
                    return this.hasCallback(t) ? this.callCallback(t, e) : this.getObjectValue(e, t.name, "")
                },
                isSpecialField: function (t) {
                    return "__" === t.slice(0, 2)
                },
                titleCase: function (t) {
                    return t.replace(/\w+/g, function (t) {
                        return t.charAt(0).toUpperCase() + t.substr(1).toLowerCase()
                    })
                },
                camelCase: function (t) {
                    var e = arguments.length > 1 && void 0 !== arguments[1] ? arguments[1] : "_",
                        n = this;
                    return t.split(e).map(function (t) {
                        return n.titleCase(t)
                    }).join("")
                },
                notIn: function (t, e) {
                    return -1 === e.indexOf(t)
                },
                loadData: function () {
                    var t = arguments.length > 0 && void 0 !== arguments[0] ? arguments[0] : this.loadSuccess,
                        e = arguments.length > 1 && void 0 !== arguments[1] ? arguments[1] : this.loadFailed;
                    return this.isDataMode ? void this.callDataManager() : (this.fireEvent("loading"), this.httpOptions.params = this.getAllQueryParams(), this.fetch(this.apiUrl, this.httpOptions).then(t, e).catch(function () {
                        return e()
                    }))
                },
                fetch: function (t, e) {
                    return this.httpFetch ? this.httpFetch(t, e) : a.a[this.httpMethod](t, e)
                },
                loadSuccess: function (t) {
                    this.fireEvent("load-success", t);
                    var e = this.transform(t.data);
                    this.tableData = this.getObjectValue(e, this.dataPath, null), this.tablePagination = this.getObjectValue(e, this.paginationPath, null), null === this.tablePagination && this.warn('vuetable: pagination-path "' + this.paginationPath + '" not found. It looks like the data returned from the sever does not have pagination information or you may have set it incorrectly.\nYou can explicitly suppress this warning by setting pagination-path="".'), this.$nextTick(function () {
                        this.fixHeader(), this.fireEvent("pagination-data", this.tablePagination), this.fireEvent("loaded")
                    })
                },
                fixHeader: function () {
                    if (this.isFixedHeader) {
                        var t = this.$el.getElementsByClassName("vuetable-body-wrapper")[0];
                        null != t && (t.scrollHeight > t.clientHeight ? this.scrollVisible = !0 : this.scrollVisible = !1)
                    }
                },
                loadFailed: function (t) {
                    console.error("load-error", t), this.fireEvent("load-error", t), this.fireEvent("loaded")
                },
                transform: function (t) {
                    return this.parentFunctionExists("transform") ? this.$parent.transform.call(this.$parent, t) : t
                },
                parentFunctionExists: function (t) {
                    return "" !== t && "function" == typeof this.$parent[t]
                },
                callParentFunction: function (t, e) {
                    var n = arguments.length > 2 && void 0 !== arguments[2] ? arguments[2] : null;
                    return this.parentFunctionExists(t) ? this.$parent[t].call(this.$parent, e) : n
                },
                fireEvent: function (t, e) {
                    this.$emit(this.eventPrefix + t, e)
                },
                warn: function (t) {
                    this.silent || console.warn(t)
                },
                getAllQueryParams: function () {
                    var t = {};
                    t[this.queryParams.sort] = this.getSortParam(), t[this.queryParams.page] = this.currentPage, t[this.queryParams.perPage] = this.perPage;
                    for (var e in this.appendParams) t[e] = this.appendParams[e];
                    return t
                },
                getSortParam: function () {
                    return this.sortOrder && "" != this.sortOrder.field ? "function" == typeof this.$parent.getSortParam ? this.$parent.getSortParam.call(this.$parent, this.sortOrder) : this.getDefaultSortParam() : ""
                },
                getDefaultSortParam: function () {
                    for (var t = "", e = 0; e < this.sortOrder.length; e++) {
                        t += (void 0 === this.sortOrder[e].sortField ? this.sortOrder[e].field : this.sortOrder[e].sortField) + "|" + this.sortOrder[e].direction + (e + 1 < this.sortOrder.length ? "," : "")
                    }
                    return t
                },
                extractName: function (t) {
                    return t.split(":")[0].trim()
                },
                extractArgs: function (t) {
                    return t.split(":")[1]
                },
                isSortable: function (t) {
                    return !(void 0 === t.sortField)
                },
                isInCurrentSortGroup: function (t) {
                    return !1 !== this.currentSortOrderPosition(t)
                },
                hasSortableIcon: function (t) {
                    return this.isSortable(t) && "" != this.css.sortableIcon
                },
                currentSortOrderPosition: function (t) {
                    if (!this.isSortable(t)) return !1;
                    for (var e = 0; e < this.sortOrder.length; e++)
                        if (this.fieldIsInSortOrderPosition(t, e)) return e;
                    return !1
                },
                fieldIsInSortOrderPosition: function (t, e) {
                    return this.sortOrder[e].field === t.name && this.sortOrder[e].sortField === t.sortField
                },
                orderBy: function (t, e) {
                    if (this.isSortable(t)) {
                        var n = this.multiSortKey.toLowerCase() + "Key";
                        this.multiSort && e[n] ? this.multiColumnSort(t) : this.singleColumnSort(t), this.currentPage = 1, this.apiMode && this.loadData()
                    }
                },
                multiColumnSort: function (t) {
                    var e = this.currentSortOrderPosition(t);
                    !1 === e ? this.sortOrder.push({
                        field: t.name,
                        sortField: t.sortField,
                        direction: "asc"
                    }) : "asc" === this.sortOrder[e].direction ? this.sortOrder[e].direction = "desc" : this.sortOrder.splice(e, 1)
                },
                singleColumnSort: function (t) {
                    0 === this.sortOrder.length && this.clearSortOrder(), this.sortOrder.splice(1), this.fieldIsInSortOrderPosition(t, 0) ? this.sortOrder[0].direction = "asc" === this.sortOrder[0].direction ? "desc" : "asc" : this.sortOrder[0].direction = "asc", this.sortOrder[0].field = t.name, this.sortOrder[0].sortField = t.sortField
                },
                clearSortOrder: function () {
                    this.sortOrder.push({
                        field: "",
                        sortField: "",
                        direction: "asc"
                    })
                },
                sortIcon: function (t) {
                    var e = this.css.sortableIcon,
                        n = this.currentSortOrderPosition(t);
                    return !1 !== n && (e = "asc" == this.sortOrder[n].direction ? this.css.ascendingIcon : this.css.descendingIcon), e
                },
                sortIconOpacity: function (t) {
                    var e = .3,
                        n = this.sortOrder.length,
                        i = this.currentSortOrderPosition(t);
                    return 1 - n * e < .3 && (e = .7 / (n - 1)), 1 - i * e
                },
                hasCallback: function (t) {
                    return !!t.callback
                },
                callCallback: function (t, e) {
                    if (this.hasCallback(t)) {
                        if ("function" == typeof t.callback) return t.callback(this.getObjectValue(e, t.name));
                        var n = t.callback.split("|"),
                            i = n.shift();
                        if ("function" == typeof this.$parent[i]) {
                            var a = this.getObjectValue(e, t.name);
                            return n.length > 0 ? this.$parent[i].apply(this.$parent, [a].concat(n)) : this.$parent[i].call(this.$parent, a)
                        }
                        return null
                    }
                },
                getObjectValue: function (t, e, n) {
                    n = void 0 === n ? null : n;
                    var i = t;
                    if ("" != e.trim()) {
                        e.split(".").forEach(function (t) {
                            if (null === i || void 0 === i[t] || null === i[t]) return void (i = n);
                            i = i[t]
                        })
                    }
                    return i
                },
                toggleCheckbox: function (t, e, n) {
                    var i = n.target.checked,
                        a = this.trackBy;
                    if (void 0 === t[a]) return void this.warn('__checkbox field: The "' + this.trackBy + '" field does not exist! Make sure the field you specify in "track-by" prop does exist.');
                    var r = t[a];
                    i ? this.selectId(r) : this.unselectId(r), this.$emit("vuetable:checkbox-toggled", i, t)
                },
                selectId: function (t) {
                    this.isSelectedRow(t) || this.selectedTo.push(t)
                },
                unselectId: function (t) {
                    this.selectedTo = this.selectedTo.filter(function (e) {
                        return e !== t
                    })
                },
                isSelectedRow: function (t) {
                    return this.selectedTo.indexOf(t) >= 0
                },
                rowSelected: function (t, e) {
                    var n = this.trackBy,
                        i = t[n];
                    return this.isSelectedRow(i)
                },
                checkCheckboxesState: function (t) {
                    if (this.tableData) {
                        var e = this,
                            n = this.trackBy,
                            i = "th.vuetable-th-checkbox-" + n + " input[type=checkbox]",
                            a = document.querySelectorAll(i);
                        void 0 === a.forEach && (a.forEach = function (t) {
                            [].forEach.call(a, t)
                        });
                        var r = this.tableData.filter(function (t) {
                            return e.selectedTo.indexOf(t[n]) >= 0
                        });
                        return r.length <= 0 ? (a.forEach(function (t) {
                            t.indeterminate = !1
                        }), !1) : r.length < this.perPage ? (a.forEach(function (t) {
                            t.indeterminate = !0
                        }), !0) : (a.forEach(function (t) {
                            t.indeterminate = !1
                        }), !0)
                    }
                },
                toggleAllCheckboxes: function (t, e) {
                    var n = this,
                        i = e.target.checked,
                        a = this.trackBy;
                    i ? this.tableData.forEach(function (t) {
                        n.selectId(t[a])
                    }) : this.tableData.forEach(function (t) {
                        n.unselectId(t[a])
                    }), this.$emit("vuetable:checkbox-toggled-all", i)
                },
                gotoPreviousPage: function () {
                    this.currentPage > 1 && (this.currentPage-- , this.loadData())
                },
                gotoNextPage: function () {
                    this.currentPage < this.tablePagination.last_page && (this.currentPage++ , this.loadData())
                },
                gotoPage: function (t) {
                    t != this.currentPage && t > 0 && t <= this.tablePagination.last_page && (this.currentPage = t, this.loadData())
                },
                isVisibleDetailRow: function (t) {
                    return this.visibleDetailRows.indexOf(t) >= 0
                },
                showDetailRow: function (t) {
                    this.isVisibleDetailRow(t) || this.visibleDetailRows.push(t)
                },
                hideDetailRow: function (t) {
                    this.isVisibleDetailRow(t) && this.visibleDetailRows.splice(this.visibleDetailRows.indexOf(t), 1)
                },
                toggleDetailRow: function (t) {
                    this.isVisibleDetailRow(t) ? this.hideDetailRow(t) : this.showDetailRow(t)
                },
                showField: function (t) {
                    t < 0 || t > this.tableFields.length || (this.tableFields[t].visible = !0)
                },
                hideField: function (t) {
                    t < 0 || t > this.tableFields.length || (this.tableFields[t].visible = !1)
                },
                toggleField: function (t) {
                    t < 0 || t > this.tableFields.length || (this.tableFields[t].visible = !this.tableFields[t].visible)
                },
                renderIconTag: function (t) {
                    var e = arguments.length > 1 && void 0 !== arguments[1] ? arguments[1] : "";
                    return void 0 === this.css.renderIcon ? '<i class="' + t.join(" ") + '" ' + e + "></i>" : this.css.renderIcon(t, e)
                },
                makePagination: function () {
                    var t = arguments.length > 0 && void 0 !== arguments[0] ? arguments[0] : null,
                        e = arguments.length > 1 && void 0 !== arguments[1] ? arguments[1] : null,
                        n = arguments.length > 2 && void 0 !== arguments[2] ? arguments[2] : null;
                    return t = null === t ? this.dataTotal : t, e = null === e ? this.perPage : e, n = null === n ? this.currentPage : n, {
                        total: t,
                        per_page: e,
                        current_page: n,
                        last_page: Math.ceil(t / e) || 0,
                        next_page_url: "",
                        prev_page_url: "",
                        from: (n - 1) * e + 1,
                        to: Math.min(n * e, t)
                    }
                },
                normalizeSortOrder: function () {
                    this.sortOrder.forEach(function (t) {
                        t.sortField = t.sortField || t.field
                    })
                },
                callDataManager: function () {
                    null === this.dataManager && null === this.data || (Array.isArray(this.data) ? (console.log("data mode: array"), this.setData(this.data)) : (this.normalizeSortOrder(), this.setData(this.dataManager(this.sortOrder, this.makePagination()))))
                },
                onRowClass: function (t, e) {
                    return "" !== this.rowClassCallback ? void this.warn('"row-class-callback" prop is deprecated, please use "row-class" prop instead.') : "function" == typeof this.rowClass ? this.rowClass(t, e) : this.rowClass
                },
                onRowChanged: function (t) {
                    return this.fireEvent("row-changed", t), !0
                },
                onRowClicked: function (t, e) {
                    return this.$emit(this.eventPrefix + "row-clicked", t, e), !0
                },
                onRowDoubleClicked: function (t, e) {
                    this.$emit(this.eventPrefix + "row-dblclicked", t, e)
                },
                onDetailRowClick: function (t, e) {
                    this.$emit(this.eventPrefix + "detail-row-clicked", t, e)
                },
                onCellClicked: function (t, e, n) {
                    this.$emit(this.eventPrefix + "cell-clicked", t, e, n)
                },
                onCellDoubleClicked: function (t, e, n) {
                    this.$emit(this.eventPrefix + "cell-dblclicked", t, e, n)
                },
                onCellRightClicked: function (t, e, n) {
                    this.$emit(this.eventPrefix + "cell-rightclicked", t, e, n)
                },
                changePage: function (t) {
                    "prev" === t ? this.gotoPreviousPage() : "next" === t ? this.gotoNextPage() : this.gotoPage(t)
                },
                reload: function () {
                    return this.loadData()
                },
                refresh: function () {
                    return this.currentPage = 1, this.loadData()
                },
                resetData: function () {
                    this.tableData = null, this.tablePagination = null, this.fireEvent("data-reset")
                }
            },
            watch: {
                multiSort: function (t, e) {
                    !1 === t && this.sortOrder.length > 1 && (this.sortOrder.splice(1), this.loadData())
                },
                apiUrl: function (t, e) {
                    this.reactiveApiUrl && t !== e && this.refresh()
                },
                data: function (t, e) {
                    this.setData(t)
                }
            }
        }
    }, function (t, e, n) {
        "use strict";
        Object.defineProperty(e, "__esModule", {
            value: !0
        });
        var i = n(2),
            a = n.n(i);
        e.default = {
            mixins: [a.a]
        }
    }, function (t, e, n) {
        "use strict";
        Object.defineProperty(e, "__esModule", {
            value: !0
        });
        var i = n(2),
            a = n.n(i);
        e.default = {
            mixins: [a.a],
            props: {
                pageText: {
                    type: String,
                    default: function () {
                        return "Page"
                    }
                }
            },
            methods: {
                registerEvents: function () {
                    var t = this;
                    this.$on("vuetable:pagination-data", function (e) {
                        t.setPaginationData(e)
                    })
                }
            },
            created: function () {
                this.registerEvents()
            }
        }
    }, function (t, e, n) {
        "use strict";
        Object.defineProperty(e, "__esModule", {
            value: !0
        });
        var i = n(4),
            a = n.n(i);
        e.default = {
            mixins: [a.a]
        }
    }, function (t, e, n) {
        "use strict";
        Object.defineProperty(e, "__esModule", {
            value: !0
        }), e.default = {
            props: {
                css: {
                    type: Object,
                    default: function () {
                        return {
                            infoClass: "left floated left aligned six wide column"
                        }
                    }
                },
                infoTemplate: {
                    type: String,
                    default: function () {
                        return "Displaying {from} to {to} of {total} items"
                    }
                },
                noDataTemplate: {
                    type: String,
                    default: function () {
                        return "No relevant data"
                    }
                }
            },
            data: function () {
                return {
                    tablePagination: null
                }
            },
            computed: {
                paginationInfo: function () {
                    return null == this.tablePagination || 0 == this.tablePagination.total ? this.noDataTemplate : this.infoTemplate.replace("{from}", this.tablePagination.from || 0).replace("{to}", this.tablePagination.to || 0).replace("{total}", this.tablePagination.total || 0)
                }
            },
            methods: {
                setPaginationData: function (t) {
                    this.tablePagination = t
                },
                resetData: function () {
                    this.tablePagination = null
                }
            }
        }
    }, function (t, e, n) {
        "use strict";
        Object.defineProperty(e, "__esModule", {
            value: !0
        }), e.default = {
            props: {
                css: {
                    type: Object,
                    default: function () {
                        return {
                            wrapperClass: "ui right floated pagination menu",
                            activeClass: "active large",
                            disabledClass: "disabled",
                            pageClass: "item",
                            linkClass: "icon item",
                            paginationClass: "ui bottom attached segment grid",
                            paginationInfoClass: "left floated left aligned six wide column",
                            dropdownClass: "ui search dropdown",
                            icons: {
                                first: "angle double left icon",
                                prev: "left chevron icon",
                                next: "right chevron icon",
                                last: "angle double right icon"
                            }
                        }
                    }
                },
                onEachSide: {
                    type: Number,
                    default: function () {
                        return 2
                    }
                }
            },
            data: function () {
                return {
                    eventPrefix: "vuetable-pagination:",
                    tablePagination: null
                }
            },
            computed: {
                totalPage: function () {
                    return null === this.tablePagination ? 0 : this.tablePagination.last_page
                },
                isOnFirstPage: function () {
                    return null !== this.tablePagination && 1 === this.tablePagination.current_page
                },
                isOnLastPage: function () {
                    return null !== this.tablePagination && this.tablePagination.current_page === this.tablePagination.last_page
                },
                notEnoughPages: function () {
                    return this.totalPage < 2 * this.onEachSide + 4
                },
                windowSize: function () {
                    return 2 * this.onEachSide + 1
                },
                windowStart: function () {
                    return !this.tablePagination || this.tablePagination.current_page <= this.onEachSide ? 1 : this.tablePagination.current_page >= this.totalPage - this.onEachSide ? this.totalPage - 2 * this.onEachSide : this.tablePagination.current_page - this.onEachSide
                }
            },
            methods: {
                loadPage: function (t) {
                    this.$emit(this.eventPrefix + "change-page", t)
                },
                isCurrentPage: function (t) {
                    return t === this.tablePagination.current_page
                },
                setPaginationData: function (t) {
                    this.tablePagination = t
                },
                resetData: function () {
                    this.tablePagination = null
                }
            }
        }
    }, function (t, e, n) {
        "use strict";

        function i(t) {
            t.component("vuetable", r.a), t.component("vuetable-pagination", s.a), t.component("vuetable-pagination-dropdown", c.a), t.component("vuetable-pagination-info", d.a)
        }
        Object.defineProperty(e, "__esModule", {
            value: !0
        }), n.d(e, "install", function () {
            return i
        });
        var a = n(12),
            r = n.n(a),
            o = n(13),
            s = n.n(o),
            l = n(14),
            c = n.n(l),
            u = n(15),
            d = n.n(u),
            f = n(2),
            h = n.n(f),
            p = n(4),
            m = n.n(p),
            v = n(11),
            g = n.n(v);
        n.d(e, "Vuetable", function () {
            return r.a
        }), n.d(e, "VuetablePagination", function () {
            return s.a
        }), n.d(e, "VuetablePaginationDropDown", function () {
            return c.a
        }), n.d(e, "VuetablePaginationInfo", function () {
            return d.a
        }), n.d(e, "VuetablePaginationMixin", function () {
            return h.a
        }), n.d(e, "VuetablePaginationInfoMixin", function () {
            return m.a
        }), window.Promise || (window.Promise = g.a), e.default = r.a
    }, function (t, e, n) {
        e = t.exports = n(42)(!1), e.push([t.i, "\n[v-cloak][data-v-5cc42bfc] {\n  display: none;\n}\n.vuetable th.sortable[data-v-5cc42bfc]:hover {\n  color: #b77147;\n  cursor: pointer;\n}\n.vuetable-body-wrapper[data-v-5cc42bfc] {\n  position:relative;\n  overflow-y:auto;\n}\n.vuetable-head-wrapper[data-v-5cc42bfc] {\n  overflow-x: hidden;\n}\n.vuetable-actions[data-v-5cc42bfc] {\n  width: 15%;\n  padding: 12px 0px;\n  text-align: center;\n}\n.vuetable-pagination[data-v-5cc42bfc] {\n  background: #f9fafb !important;\n}\n.vuetable-pagination-info[data-v-5cc42bfc] {\n  margin-top: auto;\n  margin-bottom: auto;\n}\n.vuetable-empty-result[data-v-5cc42bfc] {\n  text-align: center;\n}\n.vuetable-clip-text[data-v-5cc42bfc] {\n  white-space: pre-wrap;\n  text-overflow: ellipsis;\n  overflow: hidden;\n  display: block;\n}\n.vuetable-semantic-no-top[data-v-5cc42bfc] {\n  border-top:none !important;\n  margin-top:0 !important;\n}\n.vuetable-fixed-layout[data-v-5cc42bfc] {\n  table-layout: fixed;\n}\n.vuetable-gutter-col[data-v-5cc42bfc] {\n  padding: 0 !important;\n  border-left: none  !important;\n  border-right: none  !important;\n}\n", ""])
    }, function (t, e) {
        function n(t, e) {
            var n = t[1] || "",
                a = t[3];
            if (!a) return n;
            if (e && "function" == typeof btoa) {
                var r = i(a);
                return [n].concat(a.sources.map(function (t) {
                    return "/*# sourceURL=" + a.sourceRoot + t + " */"
                })).concat([r]).join("\n")
            }
            return [n].join("\n")
        }

        function i(t) {
            return "/*# sourceMappingURL=data:application/json;charset=utf-8;base64," + btoa(unescape(encodeURIComponent(JSON.stringify(t)))) + " */"
        }
        t.exports = function (t) {
            var e = [];
            return e.toString = function () {
                return this.map(function (e) {
                    var i = n(e, t);
                    return e[2] ? "@media " + e[2] + "{" + i + "}" : i
                }).join("")
            }, e.i = function (t, n) {
                "string" == typeof t && (t = [
                    [null, t, ""]
                ]);
                for (var i = {}, a = 0; a < this.length; a++) {
                    var r = this[a][0];
                    "number" == typeof r && (i[r] = !0)
                }
                for (a = 0; a < t.length; a++) {
                    var o = t[a];
                    "number" == typeof o[0] && i[o[0]] || (n && !o[2] ? o[2] = n : n && (o[2] = "(" + o[2] + ") and (" + n + ")"), e.push(o))
                }
            }, e
        }
    }, function (t, e, n) {
        (function (t, e) {
            ! function (t, n) {
                "use strict";

                function i(t) {
                    "function" != typeof t && (t = new Function("" + t));
                    for (var e = new Array(arguments.length - 1), n = 0; n < e.length; n++) e[n] = arguments[n + 1];
                    var i = {
                        callback: t,
                        args: e
                    };
                    return c[l] = i, s(l), l++
                }

                function a(t) {
                    delete c[t]
                }

                function r(t) {
                    var e = t.callback,
                        i = t.args;
                    switch (i.length) {
                        case 0:
                            e();
                            break;
                        case 1:
                            e(i[0]);
                            break;
                        case 2:
                            e(i[0], i[1]);
                            break;
                        case 3:
                            e(i[0], i[1], i[2]);
                            break;
                        default:
                            e.apply(n, i)
                    }
                }

                function o(t) {
                    if (u) setTimeout(o, 0, t);
                    else {
                        var e = c[t];
                        if (e) {
                            u = !0;
                            try {
                                r(e)
                            } finally {
                                a(t), u = !1
                            }
                        }
                    }
                }
                if (!t.setImmediate) {
                    var s, l = 1,
                        c = {},
                        u = !1,
                        d = t.document,
                        f = Object.getPrototypeOf && Object.getPrototypeOf(t);
                    f = f && f.setTimeout ? f : t, "[object process]" === {}.toString.call(t.process) ? function () {
                        s = function (t) {
                            e.nextTick(function () {
                                o(t)
                            })
                        }
                    }() : function () {
                        if (t.postMessage && !t.importScripts) {
                            var e = !0,
                                n = t.onmessage;
                            return t.onmessage = function () {
                                e = !1
                            }, t.postMessage("", "*"), t.onmessage = n, e
                        }
                    }() ? function () {
                        var e = "setImmediate$" + Math.random() + "$",
                            n = function (n) {
                                n.source === t && "string" == typeof n.data && 0 === n.data.indexOf(e) && o(+n.data.slice(e.length))
                            };
                        t.addEventListener ? t.addEventListener("message", n, !1) : t.attachEvent("onmessage", n), s = function (n) {
                            t.postMessage(e + n, "*")
                        }
                    }() : t.MessageChannel ? function () {
                        var t = new MessageChannel;
                        t.port1.onmessage = function (t) {
                            o(t.data)
                        }, s = function (e) {
                            t.port2.postMessage(e)
                        }
                    }() : d && "onreadystatechange" in d.createElement("script") ? function () {
                        var t = d.documentElement;
                        s = function (e) {
                            var n = d.createElement("script");
                            n.onreadystatechange = function () {
                                o(e), n.onreadystatechange = null, t.removeChild(n), n = null
                            }, t.appendChild(n)
                        }
                    }() : function () {
                        s = function (t) {
                            setTimeout(o, 0, t)
                        }
                    }(), f.setImmediate = i, f.clearImmediate = a
                }
            }("undefined" == typeof self ? void 0 === t ? this : t : self)
        }).call(e, n(52), n(10))
    }, function (t, e, n) {
        function i(t, e) {
            this._id = t, this._clearFn = e
        }
        var a = Function.prototype.apply;
        e.setTimeout = function () {
            return new i(a.call(setTimeout, window, arguments), clearTimeout)
        }, e.setInterval = function () {
            return new i(a.call(setInterval, window, arguments), clearInterval)
        }, e.clearTimeout = e.clearInterval = function (t) {
            t && t.close()
        }, i.prototype.unref = i.prototype.ref = function () { }, i.prototype.close = function () {
            this._clearFn.call(window, this._id)
        }, e.enroll = function (t, e) {
            clearTimeout(t._idleTimeoutId), t._idleTimeout = e
        }, e.unenroll = function (t) {
            clearTimeout(t._idleTimeoutId), t._idleTimeout = -1
        }, e._unrefActive = e.active = function (t) {
            clearTimeout(t._idleTimeoutId);
            var e = t._idleTimeout;
            e >= 0 && (t._idleTimeoutId = setTimeout(function () {
                t._onTimeout && t._onTimeout()
            }, e))
        }, n(43), e.setImmediate = setImmediate, e.clearImmediate = clearImmediate
    }, function (t, e) {
        t.exports = {
            render: function () {
                var t = this,
                    e = t.$createElement,
                    n = t._self._c || e;
                return n("div", {
                    class: [t.css.wrapperClass]
                }, [n("a", {
                    class: [t.css.linkClass, (i = {}, i[t.css.disabledClass] = t.isOnFirstPage, i)],
                    on: {
                        click: function (e) {
                            t.loadPage("prev")
                        }
                    }
                }, [n("i", {
                    class: t.css.icons.prev
                })]), t._v(" "), n("select", {
                    class: ["vuetable-pagination-dropdown", t.css.dropdownClass],
                    on: {
                        change: function (e) {
                            t.loadPage(e.target.selectedIndex + 1)
                        }
                    }
                }, t._l(t.totalPage, function (e) {
                    return n("option", {
                        class: [t.css.pageClass],
                        domProps: {
                            value: e,
                            selected: t.isCurrentPage(e)
                        }
                    }, [t._v("\n      " + t._s(t.pageText) + " " + t._s(e) + "\n    ")])
                })), t._v(" "), n("a", {
                    class: [t.css.linkClass, (a = {}, a[t.css.disabledClass] = t.isOnLastPage, a)],
                    on: {
                        click: function (e) {
                            t.loadPage("next")
                        }
                    }
                }, [n("i", {
                    class: t.css.icons.next
                })])]);
                var i, a
            },
            staticRenderFns: []
        }
    }, function (t, e) {
        t.exports = {
            render: function () {
                var t = this,
                    e = t.$createElement,
                    n = t._self._c || e;
                return t.isFixedHeader ? n("div", [n("div", {
                    staticClass: "vuetable-head-wrapper"
                }, [n("table", {
                    class: ["vuetable", t.css.tableClass, t.css.tableHeaderClass]
                }, [n("thead", [n("tr", [t._l(t.tableFields, function (e) {
                    return [e.visible ? [t.isSpecialField(e.name) ? ["__checkbox" == t.extractName(e.name) ? n("th", {
                        class: ["vuetable-th-checkbox-" + t.trackBy, e.titleClass],
                        style: {
                            width: e.width
                        }
                    }, [n("input", {
                        attrs: {
                            type: "checkbox"
                        },
                        domProps: {
                            checked: t.checkCheckboxesState(e.name)
                        },
                        on: {
                            change: function (n) {
                                t.toggleAllCheckboxes(e.name, n)
                            }
                        }
                    })]) : t._e(), t._v(" "), "__component" == t.extractName(e.name) ? n("th", {
                        class: ["vuetable-th-component-" + t.trackBy, e.titleClass, {
                            sortable: t.isSortable(e)
                        }],
                        style: {
                            width: e.width
                        },
                        domProps: {
                            innerHTML: t._s(t.renderTitle(e))
                        },
                        on: {
                            click: function (n) {
                                t.orderBy(e, n)
                            }
                        }
                    }) : t._e(), t._v(" "), "__slot" == t.extractName(e.name) ? n("th", {
                        class: ["vuetable-th-slot-" + t.extractArgs(e.name), e.titleClass, {
                            sortable: t.isSortable(e)
                        }],
                        style: {
                            width: e.width
                        },
                        domProps: {
                            innerHTML: t._s(t.renderTitle(e))
                        },
                        on: {
                            click: function (n) {
                                t.orderBy(e, n)
                            }
                        }
                    }) : t._e(), t._v(" "), "__sequence" == t.extractName(e.name) ? n("th", {
                        class: ["vuetable-th-sequence", e.titleClass || ""],
                        style: {
                            width: e.width
                        },
                        domProps: {
                            innerHTML: t._s(t.renderTitle(e))
                        }
                    }) : t._e(), t._v(" "), t.notIn(t.extractName(e.name), ["__sequence", "__checkbox", "__component", "__slot"]) ? n("th", {
                        class: ["vuetable-th-" + e.name, e.titleClass || ""],
                        style: {
                            width: e.width
                        },
                        domProps: {
                            innerHTML: t._s(t.renderTitle(e))
                        }
                    }) : t._e()] : [n("th", {
                        class: ["vuetable-th-" + e.name, e.titleClass, {
                            sortable: t.isSortable(e)
                        }],
                        style: {
                            width: e.width
                        },
                        attrs: {
                            id: "_" + e.name
                        },
                        domProps: {
                            innerHTML: t._s(t.renderTitle(e))
                        },
                        on: {
                            click: function (n) {
                                t.orderBy(e, n)
                            }
                        }
                    })]] : t._e()]
                }), t._v(" "), t.scrollVisible ? n("th", {
                    staticClass: "vuetable-gutter-col",
                    style: {
                        width: t.scrollBarWidth
                    }
                }) : t._e()], 2)])])]), t._v(" "), n("div", {
                    staticClass: "vuetable-body-wrapper",
                    style: {
                        height: t.tableHeight
                    }
                }, [n("table", {
                    class: ["vuetable", t.css.tableClass, t.css.tableBodyClass]
                }, [n("colgroup", [t._l(t.tableFields, function (e) {
                    return [e.visible ? [
                        [n("col", {
                            class: ["vuetable-th-" + e.name, e.titleClass],
                            style: {
                                width: e.width
                            },
                            attrs: {
                                id: "_col_" + e.name
                            }
                        })]
                    ] : t._e()]
                })], 2), t._v(" "), n("tbody", {
                    staticClass: "vuetable-body"
                }, [t._l(t.tableData, function (e, i) {
                    return [n("tr", {
                        class: t.onRowClass(e, i),
                        attrs: {
                            "item-index": i,
                            render: t.onRowChanged(e)
                        },
                        on: {
                            dblclick: function (n) {
                                t.onRowDoubleClicked(e, n)
                            },
                            click: function (n) {
                                t.onRowClicked(e, n)
                            }
                        }
                    }, [t._l(t.tableFields, function (a) {
                        return [a.visible ? [t.isSpecialField(a.name) ? ["__sequence" == t.extractName(a.name) ? n("td", {
                            class: ["vuetable-sequence", a.dataClass],
                            domProps: {
                                innerHTML: t._s(t.renderSequence(i))
                            }
                        }) : t._e(), t._v(" "), "__handle" == t.extractName(a.name) ? n("td", {
                            class: ["vuetable-handle", a.dataClass],
                            domProps: {
                                innerHTML: t._s(t.renderIconTag(["handle-icon", t.css.handleIcon]))
                            }
                        }) : t._e(), t._v(" "), "__checkbox" == t.extractName(a.name) ? n("td", {
                            class: ["vuetable-checkboxes", a.dataClass]
                        }, [n("input", {
                            attrs: {
                                type: "checkbox"
                            },
                            domProps: {
                                checked: t.rowSelected(e, a.name)
                            },
                            on: {
                                change: function (n) {
                                    t.toggleCheckbox(e, a.name, n)
                                }
                            }
                        })]) : t._e(), t._v(" "), "__component" === t.extractName(a.name) ? n("td", {
                            class: ["vuetable-component", a.dataClass]
                        }, [n(t.extractArgs(a.name), {
                            tag: "component",
                            attrs: {
                                "row-data": e,
                                "row-index": i,
                                "row-field": a.sortField
                            }
                        })], 1) : t._e(), t._v(" "), "__slot" === t.extractName(a.name) ? n("td", {
                            class: ["vuetable-slot", a.dataClass]
                        }, [t._t(t.extractArgs(a.name), null, {
                            rowData: e,
                            rowIndex: i,
                            rowField: a.sortField
                        })], 2) : t._e()] : [n("td", {
                            class: a.dataClass,
                            domProps: {
                                innerHTML: t._s(t.renderNormalField(a, e))
                            },
                            on: {
                                click: function (n) {
                                    t.onCellClicked(e, a, n)
                                },
                                dblclick: function (n) {
                                    t.onCellDoubleClicked(e, a, n)
                                },
                                contextmenu: function (n) {
                                    t.onCellRightClicked(e, a, n)
                                }
                            }
                        })]] : t._e()]
                    })], 2), t._v(" "), t.useDetailRow ? [t.isVisibleDetailRow(e[t.trackBy]) ? n("tr", {
                        class: [t.css.detailRowClass],
                        on: {
                            click: function (n) {
                                t.onDetailRowClick(e, n)
                            }
                        }
                    }, [n("transition", {
                        attrs: {
                            name: t.detailRowTransition
                        }
                    }, [n("td", {
                        attrs: {
                            colspan: t.countVisibleFields
                        }
                    }, [n(t.detailRowComponent, {
                        tag: "component",
                        attrs: {
                            "row-data": e,
                            "row-index": i
                        }
                    })], 1)])], 1) : t._e()] : t._e()]
                }), t._v(" "), t.displayEmptyDataRow ? [n("tr", [n("td", {
                    staticClass: "vuetable-empty-result",
                    attrs: {
                        colspan: t.countVisibleFields
                    }
                }, [t._v(t._s(t.noDataTemplate))])])] : t._e(), t._v(" "), t.lessThanMinRows ? t._l(t.blankRows, function (e) {
                    return n("tr", {
                        staticClass: "blank-row"
                    }, [t._l(t.tableFields, function (e) {
                        return [e.visible ? n("td", [t._v(" ")]) : t._e()]
                    })], 2)
                }) : t._e()], 2)])])]) : n("table", {
                    class: ["vuetable", t.css.tableClass]
                }, [n("thead", [n("tr", [t._l(t.tableFields, function (e) {
                    return [e.visible ? [t.isSpecialField(e.name) ? ["__checkbox" == t.extractName(e.name) ? n("th", {
                        class: ["vuetable-th-checkbox-" + t.trackBy, e.titleClass],
                        style: {
                            width: e.width
                        }
                    }, [n("input", {
                        attrs: {
                            type: "checkbox"
                        },
                        domProps: {
                            checked: t.checkCheckboxesState(e.name)
                        },
                        on: {
                            change: function (n) {
                                t.toggleAllCheckboxes(e.name, n)
                            }
                        }
                    })]) : t._e(), t._v(" "), "__component" == t.extractName(e.name) ? n("th", {
                        class: ["vuetable-th-component-" + t.trackBy, e.titleClass, {
                            sortable: t.isSortable(e)
                        }],
                        style: {
                            width: e.width
                        },
                        domProps: {
                            innerHTML: t._s(t.renderTitle(e))
                        },
                        on: {
                            click: function (n) {
                                t.orderBy(e, n)
                            }
                        }
                    }) : t._e(), t._v(" "), "__slot" == t.extractName(e.name) ? n("th", {
                        class: ["vuetable-th-slot-" + t.extractArgs(e.name), e.titleClass, {
                            sortable: t.isSortable(e)
                        }],
                        style: {
                            width: e.width
                        },
                        domProps: {
                            innerHTML: t._s(t.renderTitle(e))
                        },
                        on: {
                            click: function (n) {
                                t.orderBy(e, n)
                            }
                        }
                    }) : t._e(), t._v(" "), "__sequence" == t.extractName(e.name) ? n("th", {
                        class: ["vuetable-th-sequence", e.titleClass || ""],
                        style: {
                            width: e.width
                        },
                        domProps: {
                            innerHTML: t._s(t.renderTitle(e))
                        }
                    }) : t._e(), t._v(" "), t.notIn(t.extractName(e.name), ["__sequence", "__checkbox", "__component", "__slot"]) ? n("th", {
                        class: ["vuetable-th-" + e.name, e.titleClass || ""],
                        style: {
                            width: e.width
                        },
                        domProps: {
                            innerHTML: t._s(t.renderTitle(e))
                        }
                    }) : t._e()] : [n("th", {
                        class: ["vuetable-th-" + e.name, e.titleClass, {
                            sortable: t.isSortable(e)
                        }],
                        style: {
                            width: e.width
                        },
                        attrs: {
                            id: "_" + e.name
                        },
                        domProps: {
                            innerHTML: t._s(t.renderTitle(e))
                        },
                        on: {
                            click: function (n) {
                                t.orderBy(e, n)
                            }
                        }
                    })]] : t._e()]
                })], 2)]), t._v(" "), n("tbody", {
                    staticClass: "vuetable-body"
                }, [t._l(t.tableData, function (e, i) {
                    return [n("tr", {
                        class: t.onRowClass(e, i),
                        attrs: {
                            "item-index": i,
                            render: t.onRowChanged(e)
                        },
                        on: {
                            dblclick: function (n) {
                                t.onRowDoubleClicked(e, n)
                            },
                            click: function (n) {
                                t.onRowClicked(e, n)
                            }
                        }
                    }, [t._l(t.tableFields, function (a) {
                        return [a.visible ? [t.isSpecialField(a.name) ? ["__sequence" == t.extractName(a.name) ? n("td", {
                            class: ["vuetable-sequence", a.dataClass],
                            domProps: {
                                innerHTML: t._s(t.renderSequence(i))
                            }
                        }) : t._e(), t._v(" "), "__handle" == t.extractName(a.name) ? n("td", {
                            class: ["vuetable-handle", a.dataClass],
                            domProps: {
                                innerHTML: t._s(t.renderIconTag(["handle-icon", t.css.handleIcon]))
                            }
                        }) : t._e(), t._v(" "), "__checkbox" == t.extractName(a.name) ? n("td", {
                            class: ["vuetable-checkboxes", a.dataClass]
                        }, [n("input", {
                            attrs: {
                                type: "checkbox"
                            },
                            domProps: {
                                checked: t.rowSelected(e, a.name)
                            },
                            on: {
                                change: function (n) {
                                    t.toggleCheckbox(e, a.name, n)
                                }
                            }
                        })]) : t._e(), t._v(" "), "__component" === t.extractName(a.name) ? n("td", {
                            class: ["vuetable-component", a.dataClass]
                        }, [n(t.extractArgs(a.name), {
                            tag: "component",
                            attrs: {
                                "row-data": e,
                                "row-index": i,
                                "row-field": a.sortField
                            }
                        })], 1) : t._e(), t._v(" "), "__slot" === t.extractName(a.name) ? n("td", {
                            class: ["vuetable-slot", a.dataClass]
                        }, [t._t(t.extractArgs(a.name), null, {
                            rowData: e,
                            rowIndex: i,
                            rowField: a.sortField
                        })], 2) : t._e()] : [t.hasCallback(a) ? n("td", {
                            class: a.dataClass,
                            domProps: {
                                innerHTML: t._s(t.callCallback(a, e))
                            },
                            on: {
                                click: function (n) {
                                    t.onCellClicked(e, a, n)
                                },
                                dblclick: function (n) {
                                    t.onCellDoubleClicked(e, a, n)
                                }
                            }
                        }) : n("td", {
                            class: a.dataClass,
                            domProps: {
                                innerHTML: t._s(t.getObjectValue(e, a.name, ""))
                            },
                            on: {
                                click: function (n) {
                                    t.onCellClicked(e, a, n)
                                },
                                dblclick: function (n) {
                                    t.onCellDoubleClicked(e, a, n)
                                }
                            }
                        })]] : t._e()]
                    })], 2), t._v(" "), t.useDetailRow ? [t.isVisibleDetailRow(e[t.trackBy]) ? n("tr", {
                        class: [t.css.detailRowClass],
                        on: {
                            click: function (n) {
                                t.onDetailRowClick(e, n)
                            }
                        }
                    }, [n("transition", {
                        attrs: {
                            name: t.detailRowTransition
                        }
                    }, [n("td", {
                        attrs: {
                            colspan: t.countVisibleFields
                        }
                    }, [n(t.detailRowComponent, {
                        tag: "component",
                        attrs: {
                            "row-data": e,
                            "row-index": i
                        }
                    })], 1)])], 1) : t._e()] : t._e()]
                }), t._v(" "), t.displayEmptyDataRow ? [n("tr", [n("td", {
                    staticClass: "vuetable-empty-result",
                    attrs: {
                        colspan: t.countVisibleFields
                    },
                    domProps: {
                        innerHTML: t._s(t.noDataTemplate)
                    }
                })])] : t._e(), t._v(" "), t.lessThanMinRows ? t._l(t.blankRows, function (e) {
                    return n("tr", {
                        staticClass: "blank-row"
                    }, [t._l(t.tableFields, function (e) {
                        return [e.visible ? n("td", [t._v(" ")]) : t._e()]
                    })], 2)
                }) : t._e()], 2)])
            },
            staticRenderFns: []
        }
    }, function (t, e) {
        t.exports = {
            render: function () {
                var t = this,
                    e = t.$createElement,
                    n = t._self._c || e;
                return n("div", {
                    directives: [{
                        name: "show",
                        rawName: "v-show",
                        value: t.tablePagination && t.tablePagination.last_page > 1,
                        expression: "tablePagination && tablePagination.last_page > 1"
                    }],
                    class: t.css.wrapperClass
                }, [n("a", {
                    class: ["btn-nav", t.css.linkClass, t.isOnFirstPage ? t.css.disabledClass : ""],
                    on: {
                        click: function (e) {
                            t.loadPage(1)
                        }
                    }
                }, ["" != t.css.icons.first ? n("i", {
                    class: [t.css.icons.first]
                }) : n("span", [t._v("«")])]), t._v(" "), n("a", {
                    class: ["btn-nav", t.css.linkClass, t.isOnFirstPage ? t.css.disabledClass : ""],
                    on: {
                        click: function (e) {
                            t.loadPage("prev")
                        }
                    }
                }, ["" != t.css.icons.next ? n("i", {
                    class: [t.css.icons.prev]
                }) : n("span", [t._v(" ‹")])]), t._v(" "), t.notEnoughPages ? [t._l(t.totalPage, function (e) {
                    return [n("a", {
                        class: [t.css.pageClass, t.isCurrentPage(e) ? t.css.activeClass : ""],
                        domProps: {
                            innerHTML: t._s(e)
                        },
                        on: {
                            click: function (n) {
                                t.loadPage(e)
                            }
                        }
                    })]
                })] : [t._l(t.windowSize, function (e) {
                    return [n("a", {
                        class: [t.css.pageClass, t.isCurrentPage(t.windowStart + e - 1) ? t.css.activeClass : ""],
                        domProps: {
                            innerHTML: t._s(t.windowStart + e - 1)
                        },
                        on: {
                            click: function (n) {
                                t.loadPage(t.windowStart + e - 1)
                            }
                        }
                    })]
                })], t._v(" "), n("a", {
                    class: ["btn-nav", t.css.linkClass, t.isOnLastPage ? t.css.disabledClass : ""],
                    on: {
                        click: function (e) {
                            t.loadPage("next")
                        }
                    }
                }, ["" != t.css.icons.next ? n("i", {
                    class: [t.css.icons.next]
                }) : n("span", [t._v("› ")])]), t._v(" "), n("a", {
                    class: ["btn-nav", t.css.linkClass, t.isOnLastPage ? t.css.disabledClass : ""],
                    on: {
                        click: function (e) {
                            t.loadPage(t.totalPage)
                        }
                    }
                }, ["" != t.css.icons.last ? n("i", {
                    class: [t.css.icons.last]
                }) : n("span", [t._v("»")])])], 2)
            },
            staticRenderFns: []
        }
    }, function (t, e) {
        t.exports = {
            render: function () {
                var t = this,
                    e = t.$createElement;
                return (t._self._c || e)("div", {
                    class: ["vuetable-pagination-info", t.css.infoClass],
                    domProps: {
                        innerHTML: t._s(t.paginationInfo)
                    }
                })
            },
            staticRenderFns: []
        }
    }, function (t, e, n) {
        var i = n(41);
        "string" == typeof i && (i = [
            [t.i, i, ""]
        ]), i.locals && (t.exports = i.locals);
        n(50)("764e777c", i, !0)
    }, function (t, e, n) {
        function i(t) {
            for (var e = 0; e < t.length; e++) {
                var n = t[e],
                    i = u[n.id];
                if (i) {
                    i.refs++;
                    for (var a = 0; a < i.parts.length; a++) i.parts[a](n.parts[a]);
                    for (; a < n.parts.length; a++) i.parts.push(r(n.parts[a]));
                    i.parts.length > n.parts.length && (i.parts.length = n.parts.length)
                } else {
                    for (var o = [], a = 0; a < n.parts.length; a++) o.push(r(n.parts[a]));
                    u[n.id] = {
                        id: n.id,
                        refs: 1,
                        parts: o
                    }
                }
            }
        }

        function a() {
            var t = document.createElement("style");
            return t.type = "text/css", d.appendChild(t), t
        }

        function r(t) {
            var e, n, i = document.querySelector('style[data-vue-ssr-id~="' + t.id + '"]');
            if (i) {
                if (p) return m;
                i.parentNode.removeChild(i)
            }
            if (v) {
                var r = h++;
                i = f || (f = a()), e = o.bind(null, i, r, !1), n = o.bind(null, i, r, !0)
            } else i = a(), e = s.bind(null, i), n = function () {
                i.parentNode.removeChild(i)
            };
            return e(t),
                function (i) {
                    if (i) {
                        if (i.css === t.css && i.media === t.media && i.sourceMap === t.sourceMap) return;
                        e(t = i)
                    } else n()
                }
        }

        function o(t, e, n, i) {
            var a = n ? "" : i.css;
            if (t.styleSheet) t.styleSheet.cssText = g(e, a);
            else {
                var r = document.createTextNode(a),
                    o = t.childNodes;
                o[e] && t.removeChild(o[e]), o.length ? t.insertBefore(r, o[e]) : t.appendChild(r)
            }
        }

        function s(t, e) {
            var n = e.css,
                i = e.media,
                a = e.sourceMap;
            if (i && t.setAttribute("media", i), a && (n += "\n/*# sourceURL=" + a.sources[0] + " */", n += "\n/*# sourceMappingURL=data:application/json;base64," + btoa(unescape(encodeURIComponent(JSON.stringify(a)))) + " */"), t.styleSheet) t.styleSheet.cssText = n;
            else {
                for (; t.firstChild;) t.removeChild(t.firstChild);
                t.appendChild(document.createTextNode(n))
            }
        }
        var l = "undefined" != typeof document;
        if ("undefined" != typeof DEBUG && DEBUG && !l) throw new Error("vue-style-loader cannot be used in a non-browser environment. Use { target: 'node' } in your Webpack config to indicate a server-rendering environment.");
        var c = n(51),
            u = {},
            d = l && (document.head || document.getElementsByTagName("head")[0]),
            f = null,
            h = 0,
            p = !1,
            m = function () { },
            v = "undefined" != typeof navigator && /msie [6-9]\b/.test(navigator.userAgent.toLowerCase());
        t.exports = function (t, e, n) {
            p = n;
            var a = c(t, e);
            return i(a),
                function (e) {
                    for (var n = [], r = 0; r < a.length; r++) {
                        var o = a[r],
                            s = u[o.id];
                        s.refs-- , n.push(s)
                    }
                    e ? (a = c(t, e), i(a)) : a = [];
                    for (var r = 0; r < n.length; r++) {
                        var s = n[r];
                        if (0 === s.refs) {
                            for (var l = 0; l < s.parts.length; l++) s.parts[l]();
                            delete u[s.id]
                        }
                    }
                }
        };
        var g = function () {
            var t = [];
            return function (e, n) {
                return t[e] = n, t.filter(Boolean).join("\n")
            }
        }()
    }, function (t, e) {
        t.exports = function (t, e) {
            for (var n = [], i = {}, a = 0; a < e.length; a++) {
                var r = e[a],
                    o = r[0],
                    s = r[1],
                    l = r[2],
                    c = r[3],
                    u = {
                        id: t + ":" + a,
                        css: s,
                        media: l,
                        sourceMap: c
                    };
                i[o] ? i[o].parts.push(u) : n.push(i[o] = {
                    id: o,
                    parts: [u]
                })
            }
            return n
        }
    }, function (t, e) {
        var n;
        n = function () {
            return this
        }();
        try {
            n = n || Function("return this")() || (0, eval)("this")
        } catch (t) {
            "object" == typeof window && (n = window)
        }
        t.exports = n
    }])
});