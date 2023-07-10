"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var PagamentoDataService = /** @class */ (function () {
    function PagamentoDataService(http) {
        this.http = http;
        this.module = '/pagamentos';
    }
  PagamentoDataService.prototype.get = function () {
        return this.http.get(this.module);
    };
  return PagamentoDataService;
}());
exports.PagamentoDataService = PagamentoDataService;
//# sourceMappingURL=home.data-service.js.map
