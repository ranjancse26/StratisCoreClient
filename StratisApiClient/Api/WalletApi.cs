using System;
using System.Collections.Generic;
using RestSharp;
using StratisApiClient.Client;
using StratisApiClient.Model;

namespace StratisApiClient.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IWalletApi
    {
        /// <summary>
        /// Builds a transaction and returns the hex to use when executing the transaction. 
        /// </summary>
        /// <param name="request">An object containing the parameters used to build a transaction.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void BuildTransaction (BuildTransactionRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Creates a new wallet on this full node. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to create a wallet.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void Create (WalletCreationRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Creates a new account for a wallet.  Accounts are given the name \&quot;account i\&quot;, where i is an incremental index which starts at 0.  According to BIP44. an account at index i can only be created when the account at index (i - 1)  contains at least one transaction. For example, if three accounts named \&quot;account 0\&quot;, \&quot;account 1\&quot;,  and \&quot;account 2\&quot; already exist and contain at least one transaction, then the  the function will create \&quot;account 3\&quot;. However, if \&quot;account 2\&quot;, for example, instead contains no  transactions, then this API call returns \&quot;account 2\&quot;.  Accounts are created deterministically, which means that on any device, the accounts and addresses  for a given seed (or mnemonic) are always the same. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to create a new account in a wallet.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void CreateNewAccount (GetUnusedAccountModel request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Splits and distributes UTXOs across wallet addresses 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void DistributeUtxos (DistributeUtxosRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Generates a mnemonic to use for an HD wallet. 
        /// </summary>
        /// <param name="language">The language for the words in the mnemonic. The options are: English, French, Spanish, Japanese, ChineseSimplified and ChineseTraditional. Defaults to English.</param>
        /// <param name="wordCount">The number of words in the mnemonic. The options are: 12,15,18,21 or 24. Defaults to 12.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GenerateMnemonic (string language, int? wordCount, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Gets all addresses for a wallet account. 
        /// </summary>
        /// <param name="walletName">The name of the wallet from which to get the addresses.</param>
        /// <param name="accountName">The name of the account for which to get the addresses.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GetAllAddresses (string walletName, string accountName, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Gets the balance of a wallet in STRAT (or sidechain coin). Both the confirmed and unconfirmed balance are returned. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to retrieve the balance for.</param>
        /// <param name="accountName">The name of the account to retrieve the balance for. If no account name is supplied,  then the balance for the entire wallet (all accounts) is retrieved.</param>
        /// <param name="includeBalanceByAddress">For Cirrus we need to get Balances By Address</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GetBalance (string walletName, string accountName, bool? includeBalanceByAddress, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Gets the extended public key of a specified wallet account.  the extended public key for a wallet account 
        /// </summary>
        /// <param name="walletName">The name of the wallet from which to get the extended public key.</param>
        /// <param name="accountName"></param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GetExtPubKey (string walletName, string accountName, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Gets some general information about a wallet. This includes the network the wallet is for,  the creation date and time for the wallet, the height of the blocks the wallet currently holds,  and the number of connected nodes. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GetGeneralInfo (string name, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Gets the history of a wallet. This includes the transactions held by the entire wallet  or a single account if one is specified. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to recover the history for.</param>
        /// <param name="accountName">Optional. The name of the account to recover the history for. If no account name is specified,  the entire history of the wallet is recovered.</param>
        /// <param name="address">Optional. If set, will filter the transaction history for all transactions made to or from the given address.</param>
        /// <param name="skip">An optional value allowing (with Take) pagination of the wallet&#39;s history. If given,  the member specifies the numbers of records in the wallet&#39;s history to skip before  beginning record retrieval; otherwise the wallet history records are retrieved starting from 0.</param>
        /// <param name="take">An optional value allowing (with Skip) pagination of the wallet&#39;s history. If given,  the member specifies the number of records in the wallet&#39;s history to retrieve in this call; otherwise all  wallet history records are retrieved.</param>
        /// <param name="prevOutputTxTime">Optional, Previous OutputTxTime, used for pagination</param>
        /// <param name="prevOutputIndex">Optional, Previous PrevOutputIndex, used for pagination</param>
        /// <param name="searchQuery">An optional string that can be used to match different data in the transaction records.  It is possible to match on the following: the transaction ID, the address at which funds where received,  and the address to which funds where sent.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GetHistory (string walletName, string accountName, string address, int? skip, int? take, int? prevOutputTxTime, int? prevOutputIndex, string searchQuery, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Gets the maximum spendable balance for an account along with the fee required to spend it. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to retrieve the maximum spendable amount for.</param>
        /// <param name="feeType">The type of fee to use when working out the fee required to spend the amount.  Specify \&quot;low\&quot;, \&quot;medium\&quot;, or \&quot;high\&quot;.</param>
        /// <param name="accountName">The name of the account to retrieve the maximum spendable amount for.</param>
        /// <param name="allowUnconfirmed">A flag that specifies whether to include the unconfirmed amounts held at account addresses  as spendable.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GetMaximumSpendableBalance (string walletName, string feeType, string accountName, bool? allowUnconfirmed, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Gets the balance at a specific wallet address in STRAT (or sidechain coin).  Both the confirmed and unconfirmed balance are returned.  This method gets the UTXOs at the address which the wallet can spend. 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GetReceivedByAddress (string address, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Gets the spendable transactions for an account with the option to specify how many confirmations  a transaction needs to be included. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to retrieve the spendable transactions for.</param>
        /// <param name="accountName"></param>
        /// <param name="minConfirmations">The minimum number of confirmations a transaction needs to have to be included.  To include unconfirmed transactions, set this value to 0.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GetSpendableTransactions (string walletName, string accountName, int? minConfirmations, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Get the transaction count for the specified Wallet and Account. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to query transaction count for.</param>
        /// <param name="accountName">Optional. The name of the account to query transaction count for. If no account name is specified,  the default account is used.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GetTransactionCount (string walletName, string accountName, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Gets a fee estimate for a specific transaction.  Fee can be estimated by creating a Stratis.Bitcoin.Features.Wallet.TransactionBuildContext with no password  and then building the transaction and retrieving the fee from the context. 
        /// </summary>
        /// <param name="request">An object containing the parameters used to estimate the fee              for a specific transaction.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GetTransactionFeeEstimate (TxFeeEstimateRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Gets an unused address (in the Base58 format) for a wallet account. This address will not have been assigned  to any known UTXO (neither to pay funds into the wallet or to pay change back to the wallet). 
        /// </summary>
        /// <param name="walletName">The name of the wallet from which to get the address.</param>
        /// <param name="accountName">The name of the account for which to get the address.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GetUnusedAddress (string walletName, string accountName, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Gets a specified number of unused addresses (in the Base58 format) for a wallet account. These addresses  will not have been assigned to any known UTXO (neither to pay funds into the wallet or to pay change back  to the wallet). 
        /// </summary>
        /// <param name="walletName">The name of the wallet from which to get the addresses.</param>
        /// <param name="count">The number of addresses to retrieve.</param>
        /// <param name="accountName">The name of the account for which to get the addresses.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void GetUnusedAddresses (string walletName, string count, string accountName, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Gets a list of accounts for the specified wallet. 
        /// </summary>
        /// <param name="walletName">The name of the wallet for which to list the accounts.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void ListAccounts (string walletName, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Lists all the files found in the database 
        /// </summary>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void ListWallets (bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Loads a previously created wallet. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to load an existing wallet</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void Load (WalletLoadRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Recovers an existing wallet. 
        /// </summary>
        /// <param name="request">An object containing the parameters used to recover a wallet.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void Recover (WalletRecoveryRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Recovers a wallet using its extended public key. Note that the recovered wallet will not have a private key and is  only suitable for returning the wallet history using further API calls. 
        /// </summary>
        /// <param name="request">An object containing the parameters used to recover a wallet using its extended public key.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void RecoverViaExtPubKey (WalletExtPubRecoveryRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Removes transactions from the wallet.  You might want to remove transactions from a wallet if some unconfirmed transactions disappear  from the blockchain or the transaction fields within the wallet are updated and a refresh is required to  populate the new fields.  In one situation, you might notice several unconfirmed transaction in the wallet, which you now know were  never confirmed. You can use this API to correct this by specifying a date and time before the first  unconfirmed transaction thereby removing all transactions after this point. You can also request a resync as  part of the call, which calculates the block height for the earliest removal. The wallet sync manager then  proceeds to resync from there reinstating the confirmed transactions in the wallet. You can also cherry pick  transactions to remove by specifying their transaction ID. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to remove the transactions from.</param>
        /// <param name="ids">The IDs of the transactions to remove.</param>
        /// <param name="fromDate">A date and time after which all transactions should be removed.</param>
        /// <param name="all">A flag that specifies whether to delete all transactions from a wallet.</param>
        /// <param name="reSync">A flag that specifies whether to resync the wallet after removing the transactions.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void RemoveTransactions (string walletName, List<string> ids, DateTime? fromDate, bool? all, bool? reSync, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Sends a transaction that has already been built.  Use the /api/Wallet/build-transaction call to create transactions. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters used to a send transaction request.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void SendTransaction (SendTransactionRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Signs a message and returns the signature. 
        /// </summary>
        /// <param name="request">The object containing the parameters used to sign a message.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void SignMessage (SignMessageRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Creates requested amount of UTXOs each of equal value. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void SplitCoins (SplitCoinsRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Requests the node resyncs from a block specified by its block hash.  Internally, the specified block is taken as the new wallet tip  and all blocks after it are resynced. 
        /// </summary>
        /// <param name="model">The Hash of the block to Sync From</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void Sync (HashModel model, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Request the node resyncs starting from a given date and time.  Internally, the first block created on or after the supplied date and time  is taken as the new wallet tip and all blocks after it are resynced. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters              to request a resync.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void SyncFromDate (WalletSyncRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Verifies the signature of a message. 
        /// </summary>
        /// <param name="request">The object containing the parameters verify a signature.</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void VerifyMessage (VerifyRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
        /// <summary>
        /// Retrieves information about the wallet 
        /// </summary>
        /// <param name="walletName">The name of the wallet for which to get the stats.</param>
        /// <param name="accountName"></param>
        /// <param name="minConfirmations">The minimum number of confirmations a transaction needs to have to be included.  To include unconfirmed transactions, set this value to 0.</param>
        /// <param name="verbose">Should the request return a more detailed output</param>
        /// <param name="isCancellationRequested"></param>
        /// <param name="canBeCanceled"></param>
        /// <param name="waitHandleHandle"></param>
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param>
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param>
        /// <returns></returns>
        void WalletStats (string walletName, string accountName, int? minConfirmations, bool? verbose, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class WalletApi : IWalletApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public WalletApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletApi"/> class.
        /// </summary>
        /// <returns></returns>
        public WalletApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        /// Builds a transaction and returns the hex to use when executing the transaction. 
        /// </summary>
        /// <param name="request">An object containing the parameters used to build a transaction.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void BuildTransaction (BuildTransactionRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/build-transaction";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling BuildTransaction: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling BuildTransaction: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Creates a new wallet on this full node. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to create a wallet.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void Create (WalletCreationRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/create";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Create: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Create: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Creates a new account for a wallet.  Accounts are given the name \&quot;account i\&quot;, where i is an incremental index which starts at 0.  According to BIP44. an account at index i can only be created when the account at index (i - 1)  contains at least one transaction. For example, if three accounts named \&quot;account 0\&quot;, \&quot;account 1\&quot;,  and \&quot;account 2\&quot; already exist and contain at least one transaction, then the  the function will create \&quot;account 3\&quot;. However, if \&quot;account 2\&quot;, for example, instead contains no  transactions, then this API call returns \&quot;account 2\&quot;.  Accounts are created deterministically, which means that on any device, the accounts and addresses  for a given seed (or mnemonic) are always the same. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to create a new account in a wallet.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void CreateNewAccount (GetUnusedAccountModel request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/account";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateNewAccount: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateNewAccount: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Splits and distributes UTXOs across wallet addresses 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void DistributeUtxos (DistributeUtxosRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/distribute-utxos";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling DistributeUtxos: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DistributeUtxos: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Generates a mnemonic to use for an HD wallet. 
        /// </summary>
        /// <param name="language">The language for the words in the mnemonic. The options are: English, French, Spanish, Japanese, ChineseSimplified and ChineseTraditional. Defaults to English.</param> 
        /// <param name="wordCount">The number of words in the mnemonic. The options are: 12,15,18,21 or 24. Defaults to 12.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GenerateMnemonic (string language, int? wordCount, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/mnemonic";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (language != null) queryParams.Add("language", ApiClient.ParameterToString(language)); // query parameter
 if (wordCount != null) queryParams.Add("wordCount", ApiClient.ParameterToString(wordCount)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GenerateMnemonic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GenerateMnemonic: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets all addresses for a wallet account. 
        /// </summary>
        /// <param name="walletName">The name of the wallet from which to get the addresses.</param> 
        /// <param name="accountName">The name of the account for which to get the addresses.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GetAllAddresses (string walletName, string accountName, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling GetAllAddresses");
            
    
            var path = "/api/Wallet/addresses";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (accountName != null) queryParams.Add("AccountName", ApiClient.ParameterToString(accountName)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAllAddresses: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAllAddresses: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the balance of a wallet in STRAT (or sidechain coin). Both the confirmed and unconfirmed balance are returned. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to retrieve the balance for.</param> 
        /// <param name="accountName">The name of the account to retrieve the balance for. If no account name is supplied,  then the balance for the entire wallet (all accounts) is retrieved.</param> 
        /// <param name="includeBalanceByAddress">For Cirrus we need to get Balances By Address</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GetBalance (string walletName, string accountName, bool? includeBalanceByAddress, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling GetBalance");
            
    
            var path = "/api/Wallet/balance";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (accountName != null) queryParams.Add("AccountName", ApiClient.ParameterToString(accountName)); // query parameter
 if (includeBalanceByAddress != null) queryParams.Add("IncludeBalanceByAddress", ApiClient.ParameterToString(includeBalanceByAddress)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBalance: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBalance: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the extended public key of a specified wallet account.  the extended public key for a wallet account 
        /// </summary>
        /// <param name="walletName">The name of the wallet from which to get the extended public key.</param> 
        /// <param name="accountName"></param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GetExtPubKey (string walletName, string accountName, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling GetExtPubKey");
            
    
            var path = "/api/Wallet/extpubkey";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (accountName != null) queryParams.Add("AccountName", ApiClient.ParameterToString(accountName)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetExtPubKey: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetExtPubKey: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets some general information about a wallet. This includes the network the wallet is for,  the creation date and time for the wallet, the height of the blocks the wallet currently holds,  and the number of connected nodes. 
        /// </summary>
        /// <param name="name"></param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GetGeneralInfo (string name, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetGeneralInfo");
            
    
            var path = "/api/Wallet/general-info";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (name != null) queryParams.Add("Name", ApiClient.ParameterToString(name)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetGeneralInfo: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetGeneralInfo: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the history of a wallet. This includes the transactions held by the entire wallet  or a single account if one is specified. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to recover the history for.</param> 
        /// <param name="accountName">Optional. The name of the account to recover the history for. If no account name is specified,  the entire history of the wallet is recovered.</param> 
        /// <param name="address">Optional. If set, will filter the transaction history for all transactions made to or from the given address.</param> 
        /// <param name="skip">An optional value allowing (with Take) pagination of the wallet&#39;s history. If given,  the member specifies the numbers of records in the wallet&#39;s history to skip before  beginning record retrieval; otherwise the wallet history records are retrieved starting from 0.</param> 
        /// <param name="take">An optional value allowing (with Skip) pagination of the wallet&#39;s history. If given,  the member specifies the number of records in the wallet&#39;s history to retrieve in this call; otherwise all  wallet history records are retrieved.</param> 
        /// <param name="prevOutputTxTime">Optional, Previous OutputTxTime, used for pagination</param> 
        /// <param name="prevOutputIndex">Optional, Previous PrevOutputIndex, used for pagination</param> 
        /// <param name="searchQuery">An optional string that can be used to match different data in the transaction records.  It is possible to match on the following: the transaction ID, the address at which funds where received,  and the address to which funds where sent.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GetHistory (string walletName, string accountName, string address, int? skip, int? take, int? prevOutputTxTime, int? prevOutputIndex, string searchQuery, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling GetHistory");
            
    
            var path = "/api/Wallet/history";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (accountName != null) queryParams.Add("AccountName", ApiClient.ParameterToString(accountName)); // query parameter
 if (address != null) queryParams.Add("Address", ApiClient.ParameterToString(address)); // query parameter
 if (skip != null) queryParams.Add("Skip", ApiClient.ParameterToString(skip)); // query parameter
 if (take != null) queryParams.Add("Take", ApiClient.ParameterToString(take)); // query parameter
 if (prevOutputTxTime != null) queryParams.Add("PrevOutputTxTime", ApiClient.ParameterToString(prevOutputTxTime)); // query parameter
 if (prevOutputIndex != null) queryParams.Add("PrevOutputIndex", ApiClient.ParameterToString(prevOutputIndex)); // query parameter
 if (searchQuery != null) queryParams.Add("SearchQuery", ApiClient.ParameterToString(searchQuery)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetHistory: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetHistory: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the maximum spendable balance for an account along with the fee required to spend it. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to retrieve the maximum spendable amount for.</param> 
        /// <param name="feeType">The type of fee to use when working out the fee required to spend the amount.  Specify \&quot;low\&quot;, \&quot;medium\&quot;, or \&quot;high\&quot;.</param> 
        /// <param name="accountName">The name of the account to retrieve the maximum spendable amount for.</param> 
        /// <param name="allowUnconfirmed">A flag that specifies whether to include the unconfirmed amounts held at account addresses  as spendable.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GetMaximumSpendableBalance (string walletName, string feeType, string accountName, bool? allowUnconfirmed, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling GetMaximumSpendableBalance");
            
            // verify the required parameter 'feeType' is set
            if (feeType == null) throw new ApiException(400, "Missing required parameter 'feeType' when calling GetMaximumSpendableBalance");
            
    
            var path = "/api/Wallet/maxbalance";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (accountName != null) queryParams.Add("AccountName", ApiClient.ParameterToString(accountName)); // query parameter
 if (feeType != null) queryParams.Add("FeeType", ApiClient.ParameterToString(feeType)); // query parameter
 if (allowUnconfirmed != null) queryParams.Add("AllowUnconfirmed", ApiClient.ParameterToString(allowUnconfirmed)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetMaximumSpendableBalance: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetMaximumSpendableBalance: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the balance at a specific wallet address in STRAT (or sidechain coin).  Both the confirmed and unconfirmed balance are returned.  This method gets the UTXOs at the address which the wallet can spend. 
        /// </summary>
        /// <param name="address"></param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GetReceivedByAddress (string address, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'address' is set
            if (address == null) throw new ApiException(400, "Missing required parameter 'address' when calling GetReceivedByAddress");
            
    
            var path = "/api/Wallet/received-by-address";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (address != null) queryParams.Add("Address", ApiClient.ParameterToString(address)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetReceivedByAddress: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetReceivedByAddress: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the spendable transactions for an account with the option to specify how many confirmations  a transaction needs to be included. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to retrieve the spendable transactions for.</param> 
        /// <param name="accountName"></param> 
        /// <param name="minConfirmations">The minimum number of confirmations a transaction needs to have to be included.  To include unconfirmed transactions, set this value to 0.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GetSpendableTransactions (string walletName, string accountName, int? minConfirmations, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling GetSpendableTransactions");
            
    
            var path = "/api/Wallet/spendable-transactions";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (accountName != null) queryParams.Add("AccountName", ApiClient.ParameterToString(accountName)); // query parameter
 if (minConfirmations != null) queryParams.Add("MinConfirmations", ApiClient.ParameterToString(minConfirmations)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSpendableTransactions: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSpendableTransactions: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get the transaction count for the specified Wallet and Account. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to query transaction count for.</param> 
        /// <param name="accountName">Optional. The name of the account to query transaction count for. If no account name is specified,  the default account is used.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GetTransactionCount (string walletName, string accountName, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling GetTransactionCount");
            
    
            var path = "/api/Wallet/transactionCount";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (accountName != null) queryParams.Add("AccountName", ApiClient.ParameterToString(accountName)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTransactionCount: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTransactionCount: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets a fee estimate for a specific transaction.  Fee can be estimated by creating a Stratis.Bitcoin.Features.Wallet.TransactionBuildContext with no password  and then building the transaction and retrieving the fee from the context. 
        /// </summary>
        /// <param name="request">An object containing the parameters used to estimate the fee              for a specific transaction.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GetTransactionFeeEstimate (TxFeeEstimateRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/estimate-txfee";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTransactionFeeEstimate: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTransactionFeeEstimate: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets an unused address (in the Base58 format) for a wallet account. This address will not have been assigned  to any known UTXO (neither to pay funds into the wallet or to pay change back to the wallet). 
        /// </summary>
        /// <param name="walletName">The name of the wallet from which to get the address.</param> 
        /// <param name="accountName">The name of the account for which to get the address.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GetUnusedAddress (string walletName, string accountName, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling GetUnusedAddress");
            
    
            var path = "/api/Wallet/unusedaddress";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (accountName != null) queryParams.Add("AccountName", ApiClient.ParameterToString(accountName)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetUnusedAddress: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetUnusedAddress: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets a specified number of unused addresses (in the Base58 format) for a wallet account. These addresses  will not have been assigned to any known UTXO (neither to pay funds into the wallet or to pay change back  to the wallet). 
        /// </summary>
        /// <param name="walletName">The name of the wallet from which to get the addresses.</param> 
        /// <param name="count">The number of addresses to retrieve.</param> 
        /// <param name="accountName">The name of the account for which to get the addresses.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void GetUnusedAddresses (string walletName, string count, string accountName, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling GetUnusedAddresses");
            
            // verify the required parameter 'count' is set
            if (count == null) throw new ApiException(400, "Missing required parameter 'count' when calling GetUnusedAddresses");
            
    
            var path = "/api/Wallet/unusedaddresses";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (accountName != null) queryParams.Add("AccountName", ApiClient.ParameterToString(accountName)); // query parameter
 if (count != null) queryParams.Add("Count", ApiClient.ParameterToString(count)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetUnusedAddresses: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetUnusedAddresses: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets a list of accounts for the specified wallet. 
        /// </summary>
        /// <param name="walletName">The name of the wallet for which to list the accounts.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void ListAccounts (string walletName, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling ListAccounts");
            
    
            var path = "/api/Wallet/accounts";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListAccounts: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListAccounts: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Lists all the files found in the database 
        /// </summary>
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void ListWallets (bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/list-wallets";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListWallets: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListWallets: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Loads a previously created wallet. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to load an existing wallet</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void Load (WalletLoadRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/load";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Load: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Load: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Recovers an existing wallet. 
        /// </summary>
        /// <param name="request">An object containing the parameters used to recover a wallet.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void Recover (WalletRecoveryRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/recover";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Recover: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Recover: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Recovers a wallet using its extended public key. Note that the recovered wallet will not have a private key and is  only suitable for returning the wallet history using further API calls. 
        /// </summary>
        /// <param name="request">An object containing the parameters used to recover a wallet using its extended public key.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void RecoverViaExtPubKey (WalletExtPubRecoveryRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/recover-via-extpubkey";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RecoverViaExtPubKey: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RecoverViaExtPubKey: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Removes transactions from the wallet.  You might want to remove transactions from a wallet if some unconfirmed transactions disappear  from the blockchain or the transaction fields within the wallet are updated and a refresh is required to  populate the new fields.  In one situation, you might notice several unconfirmed transaction in the wallet, which you now know were  never confirmed. You can use this API to correct this by specifying a date and time before the first  unconfirmed transaction thereby removing all transactions after this point. You can also request a resync as  part of the call, which calculates the block height for the earliest removal. The wallet sync manager then  proceeds to resync from there reinstating the confirmed transactions in the wallet. You can also cherry pick  transactions to remove by specifying their transaction ID. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to remove the transactions from.</param> 
        /// <param name="ids">The IDs of the transactions to remove.</param> 
        /// <param name="fromDate">A date and time after which all transactions should be removed.</param> 
        /// <param name="all">A flag that specifies whether to delete all transactions from a wallet.</param> 
        /// <param name="reSync">A flag that specifies whether to resync the wallet after removing the transactions.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void RemoveTransactions (string walletName, List<string> ids, DateTime? fromDate, bool? all, bool? reSync, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling RemoveTransactions");
            
    
            var path = "/api/Wallet/remove-transactions";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (ids != null) queryParams.Add("ids", ApiClient.ParameterToString(ids)); // query parameter
 if (fromDate != null) queryParams.Add("fromDate", ApiClient.ParameterToString(fromDate)); // query parameter
 if (all != null) queryParams.Add("all", ApiClient.ParameterToString(all)); // query parameter
 if (reSync != null) queryParams.Add("ReSync", ApiClient.ParameterToString(reSync)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RemoveTransactions: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RemoveTransactions: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Sends a transaction that has already been built.  Use the /api/Wallet/build-transaction call to create transactions. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters used to a send transaction request.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void SendTransaction (SendTransactionRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/send-transaction";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling SendTransaction: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling SendTransaction: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Signs a message and returns the signature. 
        /// </summary>
        /// <param name="request">The object containing the parameters used to sign a message.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void SignMessage (SignMessageRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/signmessage";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling SignMessage: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling SignMessage: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Creates requested amount of UTXOs each of equal value. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void SplitCoins (SplitCoinsRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/splitcoins";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling SplitCoins: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling SplitCoins: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Requests the node resyncs from a block specified by its block hash.  Internally, the specified block is taken as the new wallet tip  and all blocks after it are resynced. 
        /// </summary>
        /// <param name="model">The Hash of the block to Sync From</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void Sync (HashModel model, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/sync";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(model); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Sync: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Sync: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Request the node resyncs starting from a given date and time.  Internally, the first block created on or after the supplied date and time  is taken as the new wallet tip and all blocks after it are resynced. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters              to request a resync.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void SyncFromDate (WalletSyncRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/sync-from-date";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling SyncFromDate: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling SyncFromDate: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Verifies the signature of a message. 
        /// </summary>
        /// <param name="request">The object containing the parameters verify a signature.</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void VerifyMessage (VerifyRequest request, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
    
            var path = "/api/Wallet/verifymessage";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                    postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling VerifyMessage: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling VerifyMessage: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Retrieves information about the wallet 
        /// </summary>
        /// <param name="walletName">The name of the wallet for which to get the stats.</param> 
        /// <param name="accountName"></param> 
        /// <param name="minConfirmations">The minimum number of confirmations a transaction needs to have to be included.  To include unconfirmed transactions, set this value to 0.</param> 
        /// <param name="verbose">Should the request return a more detailed output</param> 
        /// <param name="isCancellationRequested"></param> 
        /// <param name="canBeCanceled"></param> 
        /// <param name="waitHandleHandle"></param> 
        /// <param name="waitHandleSafeWaitHandleIsInvalid"></param> 
        /// <param name="waitHandleSafeWaitHandleIsClosed"></param> 
        /// <returns></returns>            
        public void WalletStats (string walletName, string accountName, int? minConfirmations, bool? verbose, bool? isCancellationRequested, bool? canBeCanceled, Dictionary<string, string> waitHandleHandle, bool? waitHandleSafeWaitHandleIsInvalid, bool? waitHandleSafeWaitHandleIsClosed)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling WalletStats");
            
    
            var path = "/api/Wallet/wallet-stats";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (accountName != null) queryParams.Add("AccountName", ApiClient.ParameterToString(accountName)); // query parameter
 if (minConfirmations != null) queryParams.Add("MinConfirmations", ApiClient.ParameterToString(minConfirmations)); // query parameter
 if (verbose != null) queryParams.Add("Verbose", ApiClient.ParameterToString(verbose)); // query parameter
 if (isCancellationRequested != null) queryParams.Add("IsCancellationRequested", ApiClient.ParameterToString(isCancellationRequested)); // query parameter
 if (canBeCanceled != null) queryParams.Add("CanBeCanceled", ApiClient.ParameterToString(canBeCanceled)); // query parameter
 if (waitHandleHandle != null) queryParams.Add("WaitHandle.Handle", ApiClient.ParameterToString(waitHandleHandle)); // query parameter
 if (waitHandleSafeWaitHandleIsInvalid != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsInvalid", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsInvalid)); // query parameter
 if (waitHandleSafeWaitHandleIsClosed != null) queryParams.Add("WaitHandle.SafeWaitHandle.IsClosed", ApiClient.ParameterToString(waitHandleSafeWaitHandleIsClosed)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling WalletStats: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling WalletStats: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
