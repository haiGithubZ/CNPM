using SportSvc.Application.DTO;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Contracts
{
    public interface ISportSvcRepository
    {
        #region Sport
        Task<Sport> CreateSport(Sport sport, CancellationToken cancellationToken);
        Task<List<Sport>> GetAllSports();
        #endregion

        #region CityDistrictWard
        Task<List<CityDTO>> GetAllCity();
        Task<List<DistrictDTO>> GetAllDistrict(string city_code);
        Task<List<WardDTO>> GetAllWard(string district_code);
        #endregion

        #region Address
        Task<Address> AddAddressByUser(Address address, CancellationToken cancellationToken);
        Task<Address> DeleteAddressByUser(string addressId, CancellationToken cancellationToken);
        Task<List<Address>> ViewAllAddressByUser(string UserId, CancellationToken cancellationToken);
        Task<Address> UpdateAddressByUser(AddressDTO addressDTO, CancellationToken cancellationToken);
        Task<Address> RegisterAddressDefault(string addressid, CancellationToken cancellationToken);
        #endregion

        #region Voucher
        Task<Voucher> CreateVoucher(Voucher voucher, CancellationToken cancellationToken);
        Task<List<Voucher>> ShowAllVoucherValid();
        Task<Voucher> AddVoucherToShoppingCart(string voucherCode, string ShoppingCartId, CancellationToken cancellationToken);
        Task<int> DeleteVoucherForShoppingCart(string ShoppingCartId, CancellationToken cancellationToken);
        #endregion

        #region ShoppingCart
        Task<ShoppingCartItem> AddProductToShoppingCart(string ProductId, int Quantity, string Size, string Color, string UserId, CancellationToken cancellationToken);
        Task<List<ShoppingCartItem>> DeleteProductToShopingCart(List<string> ShoppingCartItemId, CancellationToken cancellationToken);
        Task<ViewShoppingCartDTO> ViewShoppingCartByUser(string UserId, CancellationToken cancellationToken);
        Task<double> GetTotalMoneyInShoppingCart(double intoMoney, string VoucherCode, CancellationToken cancellationToken);
        Task<Information> GetInformationDefault(string UserId, CancellationToken cancellationToken);
        Task<Bill> GetShoppingOrder(Information information, string ShoppingCartId, CancellationToken cancellationToken);
        Task<List<Bill>> ViewAllTransactionHistory(string UserId, CancellationToken cancellationToken);
        Task<Bill> SearchAndDetailBill(string code, string UserId, CancellationToken cancellationToken);
        Task<int> ConfirmShoppingOrder(int Status, string code, string UserId, CancellationToken cancellationToken);
        Task<int> CanceledOrder(string code, string UserId, CancellationToken cancellationToken);
        #endregion
    }
}
