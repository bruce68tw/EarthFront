//use ethers.js (umd version), ES6 syntax
var _ether = {

    provider: null,

    /**
     * initial
     * param {any} nodeUrl
     * return void
     */
    init: function (nodeUrl) {
        _ether.provider = ethers.getDefaultProvider(nodeUrl);
    },

    /**
     * get account balance
     * param account {uuid}
     * param fnCallback {function} (ethValue)=>{}
     * return void
     */
    getBalance: function (account, fnCallback) {
        _ether.provider.getBalance(account).then((wei) => {
            // convert a currency unit from wei to ether
            //var balanceInEth = ethers.utils.formatEther(wei);
            //console.log(`balance: ${balanceInEth} ETH`);
            fnCallback(_ether.weiToEth(wei));
        });
    },

    weiToEth: function (wei) {
        return ethers.utils.formatEther(wei);
    },

}; //class