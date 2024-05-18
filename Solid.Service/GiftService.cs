
using AutoMapper;
using Gifts;
using Solid.Core.DTO;
using Solid.Core.Entity;
using Solid.Core.Repositories;
using Solid.Core.Services;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class GiftService : IGiftService
    {
        private readonly IGiftsRepository _repository;
        private readonly IMapper _mapper;
        public GiftService(IGiftsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GiftDTO> AddAsync(Gift gift)
        {
            return _mapper.Map<GiftDTO>(await _repository.AddAsync(gift));
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<GiftDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<GiftDTO>(await _repository.GetByIdAsync(id));
        }

        public async Task<List<GiftDTO>> GetFilteredGifts(double Age = 0, double EstimatedPrice = 0, int Gender1 = 1, int Events = 1, int Categry = 1)
        {

            List<GiftDTO> giftDTOs = await GetListAsync();
            giftDTOs = giftDTOs.Where(item => (Gender1 == 1 || item.GenderId == 1 || item.GenderId == Gender1) && (Events == 1 || item.EventsId == 1 || Events == item.EventsId) && (Categry == 1 || item.CategryId == 1 || Categry == item.CategryId)).ToList();
            double start = 0, end = 120;
            if (Age >= 0)
            {
                if (Age >= 90)
                {
                    start = 90;
                }

                else
                {
                    if (Age >= 70)
                    {
                        start = 70;
                        end = 90;
                    }
                    else
                    {
                        if (Age >= 40)
                        {
                            start = Math.Max(40, Age - 10);
                            end = Math.Min(70, Age + 10);
                        }
                        else
                        {
                            if (Age >= 30)
                            {
                                start = Age - 7.5;
                                end = Age + 7.5;
                            }
                            else
                            {
                                if (Age >= 20)
                                {
                                    start = Age - 5;
                                    end = Age + 5;
                                }
                                if (Age >= 15)
                                {
                                    start = 15;
                                    end = 20;
                                }
                                else if (Age >= 10)
                                {
                                    start = Age - 2.5; end = Age + 4;
                                }
                                else
                                {
                                    if (Age >= 6)
                                    {
                                        start = Math.Max(Age - 2, 6);
                                        end = Math.Min(11, Age + 3);
                                    }
                                    else
                                    {
                                        if (Age >= 3)
                                        {
                                            start = Age - 1;
                                            end = Age + 1;
                                        }
                                        else
                                        {
                                            start = Age; end = Age;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            giftDTOs = giftDTOs.Where(item => item.EndingAge <= end && item.StartingAge >= start).ToList();
            double startPrice = 0, endPrice = 100000000;
            if (EstimatedPrice >= 0)
            {
                startPrice = EstimatedPrice + Math.Min(EstimatedPrice, EstimatedPrice < 100 ? 30 : EstimatedPrice < 1000 ? EstimatedPrice * 0.22 : EstimatedPrice * 0.3);
                endPrice = EstimatedPrice - startPrice + EstimatedPrice;
            }
            ///////////////////////////////////////////////////////////////////////
            giftDTOs = giftDTOs.Where(item => item.EstimatedPrice <= endPrice && item.EstimatedPrice >= startPrice).ToList();
            return giftDTOs;
        }

        public async Task<List<GiftDTO>> GetListAsync()
        {
            return _mapper.Map<List<GiftDTO>>(await _repository.GetListAsync()); 

        }

        public async Task<List<OpinionDTO>> GetOpinionAsync(int giftId)
        {
            return _mapper.Map<List<OpinionDTO>>(await _repository.GetOpinionAsync(giftId));
        }
    }
}
