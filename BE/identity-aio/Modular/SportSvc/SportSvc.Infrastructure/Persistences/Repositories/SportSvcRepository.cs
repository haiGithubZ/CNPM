using AutoMapper;
using Jhipster.Infrastructure.Data;
using JHipsterNet.Core.Pagination;
using Microsoft.EntityFrameworkCore;
using SportSvc.Application.Contracts;
using SportSvc.Application.DTO;
using SportSvc.Domain.Abstractions;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Infrastructure.Persistences.Repositories
{
    public class SportSvcRepository : ISportSvcRepository
    {
        private readonly ApplicationDatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public SportSvcRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        private static string GenerateOrderCode()
        {
            int length = 15;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            StringBuilder code = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(0, chars.Length);
                code.Append(chars[index]);
            }

            return code.ToString();
        }

        #region Sport
        public async Task<Sport> CreateSport(Sport sport, CancellationToken cancellationToken)
        {
            await _dbContext.Sports.AddAsync(sport);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return sport;
        }
        public async Task<List<Sport>> GetAllSports()
        {
            var list = await _dbContext.Sports.ToListAsync();
            return list;
        }
        #endregion

        #region CityDistrictWard
        public async Task<List<CityDTO>> GetAllCity()
        {
            var listCity = await _dbContext.Citys.ToListAsync();
            var list = _mapper.Map<List<CityDTO>>(listCity);   
            return list;
        }
        public async Task<List<DistrictDTO>> GetAllDistrict(string city_code)
        {
            var listDistrict = await _dbContext.Districts.Where(i => i.city_code == city_code).ToListAsync();
            var list = _mapper.Map<List<DistrictDTO>>(listDistrict);
            return list;
        }
        public async Task<List<WardDTO>> GetAllWard(string district_code)
        {
            var listWard = await _dbContext.Wards.Where(i => i.district_code == district_code).ToListAsync();
            var list = _mapper.Map<List<WardDTO>>(listWard);
            return list;
        }
        #endregion

        #region Address
        public async Task<Address> AddAddressByUser(Address address, CancellationToken cancellationToken)
        {
            var checkUser = await _dbContext.Users.Where(i => i.Id == address.UserId).FirstOrDefaultAsync();
            if (checkUser == null) throw new Exception("Fail"); 
            if(address.Status == 0)
            {
                var adre = await _dbContext.Addresss.Where(i => i.UserId == address.UserId && i.Status ==0).FirstOrDefaultAsync();
                adre.Status = 1;
            }
            await _dbContext.Addresss.AddAsync(address);
            _dbContext.SaveChanges();
            return address;
        }

        public async Task<Address> DeleteAddressByUser(string addressId, CancellationToken cancellationToken)
        {
            var check = await _dbContext.Addresss.Where(i => i.Id == addressId).FirstOrDefaultAsync();
            if (check == null) throw new Exception("Fail");
            if (check.Status == 0)
            {
                var adre = await _dbContext.Addresss.Where(i => i.UserId == check.UserId).FirstOrDefaultAsync();
                if(adre != null) adre.Status = 0;
            }
            _dbContext.Addresss.Remove(check);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return check;
        }

        public async Task<List<Address>> ViewAllAddressByUser(string UserId, CancellationToken cancellationToken)
        {
            var checkUser = await _dbContext.Users.Where(i => i.Id == UserId).FirstOrDefaultAsync();
            if (checkUser == null) throw new Exception("Fail");
            var listAddress = await _dbContext.Addresss.Where(i => i.UserId == UserId).ToListAsync();
            return listAddress;
        }

        public async Task<Address> UpdateAddressByUser(AddressDTO addressDTO, CancellationToken cancellationToken)
        {
            var checkAddress = await _dbContext.Addresss.Where(i => i.Id == addressDTO.Id && i.UserId == addressDTO.UserId).FirstOrDefaultAsync();
            if (checkAddress == null) throw new Exception("Fail");
            if(!string.IsNullOrEmpty(addressDTO.Status.ToString()))
            {
                if(addressDTO.Status == 0)
                {
                    var adre = await _dbContext.Addresss.Where(i => i.UserId == addressDTO.UserId && i.Status == 0).FirstOrDefaultAsync();
                    adre.Status = 1;
                }
                else if(checkAddress.Status == 0)
                {
                    var adre = await _dbContext.Addresss.Where(i => i.UserId == addressDTO.UserId).FirstOrDefaultAsync();
                    if (adre != null) adre.Status = 0;
                }
            }
            if(!string.IsNullOrEmpty(addressDTO.City)) checkAddress.City = addressDTO.City;
            if (!string.IsNullOrEmpty(addressDTO.District)) checkAddress.District = addressDTO.District;
            if (!string.IsNullOrEmpty(addressDTO.Ward)) checkAddress.Ward = addressDTO.Ward;
            if (!string.IsNullOrEmpty(addressDTO.Status.ToString())) checkAddress.Status = addressDTO.Status;

            checkAddress.LastModifiedDate = DateTime.Now;
            _dbContext.SaveChanges();
            return checkAddress;
        }

        public async Task<Address> RegisterAddressDefault(string addressid, CancellationToken cancellationToken)
        {
            var checkAddress = await _dbContext.Addresss.Where(i => i.Id == addressid).FirstOrDefaultAsync();
            if (checkAddress == null) throw new Exception("Fail");
            checkAddress.Status = 0;
            checkAddress.LastModifiedDate = DateTime.Now;
            //Set All to 1
            var adre = await _dbContext.Addresss.Where(i => i.UserId == checkAddress.UserId && i.Status == 0).FirstOrDefaultAsync();
            if(adre != null && adre != checkAddress)
            {
                adre.Status = 1;
                adre.LastModifiedDate = DateTime.Now;
            }
            _dbContext.SaveChanges();
            return checkAddress;
        }
        #endregion

        #region Voucher
        public async Task<Voucher> CreateVoucher(Voucher voucher, CancellationToken cancellationToken)
        {
            await _dbContext.Vouchers.AddAsync(voucher);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return voucher;
        }
        public async Task<List<Voucher>> ShowAllVoucherValid()
        {
            var listVoucher = await _dbContext.Vouchers.Where(i => i.StartDate <= DateTime.Now && i.EndDate >= DateTime.Now).ToListAsync();
            return listVoucher;
        }
        public async Task<Voucher> AddVoucherToShoppingCart(string voucherCode, string ShoppingCartId, CancellationToken cancellationToken)
        {
            var checkVoucher = await _dbContext.Vouchers.Where(i => i.Name.Equals(voucherCode)).AsNoTracking().FirstOrDefaultAsync();
            if (checkVoucher == null) throw new Exception("Voucher does not exist");
            if (checkVoucher.StartDate > DateTime.Now && checkVoucher.EndDate < DateTime.Now) throw new Exception("Invalid");
            var checkShoppingCart = await _dbContext.ShoppingCarts.Where(i => i.Id == ShoppingCartId).AsNoTracking().FirstOrDefaultAsync();
            if (checkShoppingCart.VoucherId == null)
            {
                checkShoppingCart.VoucherId = new List<string>();
                checkShoppingCart.VoucherId.Add(voucherCode);
            }
            else throw new Exception("Voucher limited quantity");
            _dbContext.ShoppingCarts.Update(checkShoppingCart);
            _dbContext.SaveChanges();
            return checkVoucher;
        }

        public async Task<int> DeleteVoucherForShoppingCart(string ShoppingCartId, CancellationToken cancellationToken)
        {
            var checkShoppingCart = await _dbContext.ShoppingCarts.Where(i => i.Id == ShoppingCartId).AsNoTracking().FirstOrDefaultAsync();
            if (checkShoppingCart == null) throw new Exception("Fail");
            if(checkShoppingCart.VoucherId != null)
            {
                checkShoppingCart.VoucherId = null;
                _dbContext.Update(checkShoppingCart);
                _dbContext.SaveChanges();
            }
            return 1;
        }
        #endregion

        #region ShoppingCart
        public async Task<ShoppingCartItem> AddProductToShoppingCart(string ProductId, int Quantity, string Size, string Color, string UserId, CancellationToken cancellationToken)
        {
            var checkUser = await _dbContext.Users.Where(i => i.Id == UserId).FirstOrDefaultAsync();
            if (checkUser == null) throw new Exception("Fail");
            var checkShoppingCart = await _dbContext.ShoppingCarts.Where(i => i.UserId == UserId).FirstOrDefaultAsync();
            var checkProduct = await _dbContext.Products.Where(i => i.Id == ProductId).FirstOrDefaultAsync();
            if(checkProduct == null) throw new Exception("Fail");
            var promotionValue = await _dbContext.Promotions.Where(i => i.ProductId == ProductId && i.StartDate <= DateTime.Now && i.EndDate >= DateTime.Now).OrderByDescending(i => i.Discount).Take(1).FirstOrDefaultAsync();

            var newShoppingCartIterm = new ShoppingCartItem()
            {
                ShoppingCartId = checkShoppingCart.Id,
                ProductId = ProductId,
                Image = checkProduct.Image,
                ProductName = checkProduct.Name,
                SportName = await _dbContext.Sports.Where(i => i.Id == checkProduct.SportId).Select(i => i.Name).AsNoTracking().FirstOrDefaultAsync(),
                ProductPrice = checkProduct.Price
            };
            if (Quantity <= checkProduct.Quantity)
            {
                newShoppingCartIterm.Quantity = Quantity;
                checkProduct.Quantity = checkProduct.Quantity - Quantity; //sp trong kho bot di
                checkProduct.NumberSold = checkProduct.NumberSold + Quantity;
                if(promotionValue!= null) newShoppingCartIterm.Price = Quantity * checkProduct.Price * (100-promotionValue.Discount)/100;
                else newShoppingCartIterm.Price = Quantity * checkProduct.Price;
            }
            else throw new Exception("Fail");
            if (!string.IsNullOrEmpty(Size) && checkProduct.ListSize.Contains(Size)) newShoppingCartIterm.Size = Size;
            if (!string.IsNullOrEmpty(Color) && checkProduct.ListColor.Contains(Color)) newShoppingCartIterm.Color = Color;

            await _dbContext.ShoppingCartItems.AddAsync(newShoppingCartIterm);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return newShoppingCartIterm;
        }
        public async Task<List<ShoppingCartItem>> DeleteProductToShopingCart(List<string> ShoppingCartItemId, CancellationToken cancellationToken)
        {
            var checkShoppingCartItem = await _dbContext.ShoppingCartItems.Where(i => ShoppingCartItemId.Contains(i.Id)).ToListAsync();
            if (checkShoppingCartItem == null) throw new Exception("Fail");

            foreach (var item in checkShoppingCartItem)
            {
                var checkProduct = await _dbContext.Products.Where(i => i.Id == item.ProductId).FirstOrDefaultAsync();
                if (checkProduct != null)
                {
                    checkProduct.Quantity = checkProduct.Quantity + item.Quantity.Value;
                    checkProduct.NumberSold = checkProduct.NumberSold - item.Quantity.Value;
                }
            }
            _dbContext.ShoppingCartItems.RemoveRange(checkShoppingCartItem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return checkShoppingCartItem;
        }
        public async Task<ViewShoppingCartDTO> ViewShoppingCartByUser(string UserId, CancellationToken cancellationToken)
        {
            var checkUer = await _dbContext.Users.Where(i => i.Id == UserId).FirstOrDefaultAsync();
            if (checkUer == null) throw new Exception("Fail");

            var userShoppingCart = await _dbContext.ShoppingCarts.Where(i => i.UserId == UserId).FirstOrDefaultAsync();
            var listItem = await _dbContext.ShoppingCartItems.Where(i => i.ShoppingCartId == userShoppingCart.Id).ToListAsync();

            var result = new ViewShoppingCartDTO()
            {
                Id = userShoppingCart.Id,
                listShoppingCartItem = listItem,
                Quantity = listItem.Count(),
                IntoMonney = (double)listItem.Sum(i => i.Price),
            };
            return result;
        }
        public async Task<double> GetTotalMoneyInShoppingCart(double intoMoney, string VoucherCode, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(VoucherCode)) return intoMoney;
            else
            {
                var checkVoucher = await _dbContext.Vouchers.Where(i => i.Name.Equals(VoucherCode)).FirstOrDefaultAsync();
                if (checkVoucher == null) throw new Exception("Voucher does not exist");
                var sales = checkVoucher.Value;
                if ((intoMoney - sales) < 0) return 0;
                else return ((double)(intoMoney - sales));
            }
        }
        public async Task<Information> GetInformationDefault(string UserId, CancellationToken cancellationToken)
        {
            var checkUser = await _dbContext.Users.Where(i => i.Id == UserId).FirstOrDefaultAsync();
            if (checkUser == null) throw new Exception("Fail");

            var checkAddressDefault = await _dbContext.Addresss.Where(i => i.Status == 0).AsNoTracking().FirstOrDefaultAsync();
            return new Information()
            {
                FullName = checkUser.FirstName + " " + checkUser.LastName,
                PhoneNumber = checkUser.PhoneNumber,
                City = checkAddressDefault.City,
                District = checkAddressDefault.District,
                Ward = checkAddressDefault.Ward
            };
        }
        public async Task<Bill> GetShoppingOrder(Information information, string ShoppingCartId, CancellationToken cancellationToken)
        {
            var checkShoppingCart = await _dbContext.ShoppingCarts.Where(i => i.Id == ShoppingCartId).FirstOrDefaultAsync();
            if (checkShoppingCart == null) throw new Exception("Fail");
            Voucher checkVoucher = null;
            if(checkShoppingCart.VoucherId != null)
            {
                checkVoucher = await _dbContext.Vouchers.Where(i => i.Name == checkShoppingCart.VoucherId.First()).FirstOrDefaultAsync();
            }
            

            var temp = await ViewShoppingCartByUser(checkShoppingCart.UserId, cancellationToken);
            var result = new Bill()
            {
                Code = GenerateOrderCode(),
                UserId = checkShoppingCart.UserId,
                ShoppingCartItemId = temp.listShoppingCartItem.Select(i => i.Id).ToList(),
                Ship = 30000,
                ValueVoucher = (checkVoucher==null) ? 0 : checkVoucher.Value,
                Status = 1, //Dang van chuyen
                DeliveryName = "Giao hàng nhanh",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                InformationDelivery = information.FullName + " | " + information.PhoneNumber 
                            + "\n" + information.Ward + ", " + information.District + ", " + information.City,
                CreatedDate = DateTime.Now,
            };
            result.TotalMoney = (temp.IntoMonney + result.Ship - result.ValueVoucher) > 0 ? (temp.IntoMonney + result.Ship - result.ValueVoucher) : 0;
            await _dbContext.Bills.AddAsync(result);

            _dbContext.ShoppingCartItems.RemoveRange(temp.listShoppingCartItem);

            checkShoppingCart.VoucherId = null;
            _dbContext.ShoppingCarts.Update(checkShoppingCart);
            _dbContext.SaveChanges();

            return result;
        }
        
        public async Task<List<Bill>> ViewAllTransactionHistory(string UserId, CancellationToken cancellationToken)
        {
            var listBill = await _dbContext.Bills.Where(i => i.UserId == UserId).ToListAsync();
            return listBill;
        }

        public async Task<Bill> SearchAndDetailBill(string code, string UserId, CancellationToken cancellationToken)
        {
            var checkBill = await _dbContext.Bills.Where(i => i.Code.Equals(code) && i.UserId == UserId).AsNoTracking().FirstOrDefaultAsync();
            if (checkBill == null) throw new Exception("Bill does not exist");
            return checkBill;
        }

        public async Task<int> ConfirmShoppingOrder(int Status, string code, string UserId, CancellationToken cancellationToken)
        {
            var checkBill = await _dbContext.Bills.Where(i => i.Code.Equals(code) && i.UserId == UserId).AsNoTracking().FirstOrDefaultAsync();
            if (checkBill == null) throw new Exception("Bill does not exist");
            checkBill.Status = Status;
            _dbContext.Update(checkBill);
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CanceledOrder(string code, string UserId, CancellationToken cancellationToken)
        {
            var checkBill = await _dbContext.Bills.Where(i => i.Code.Equals(code) && i.UserId == UserId).AsNoTracking().FirstOrDefaultAsync();
            if (checkBill == null) throw new Exception("Bill does not exist");

            if (checkBill.CreatedDate.AddHours(24) < DateTime.Now) throw new Exception("Don't canceled");
            checkBill.Status = 3; //huy
            checkBill.LastModifiedDate = DateTime.Now;
            _dbContext.Update(checkBill);
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}
