
using AutoMapper;
using Gifts;
using Solid.Core.DTO;
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

        public async Task<List<GiftDTO>> GetFilteredGifts(double Age = 0, double EstimatedPrice = 0, bool Gender = false, EEvents Events = 0, ECategory Categry = 0)
        {
            List<GiftDTO> helping = new List<GiftDTO>();
            List<GiftDTO> giftDTOs = new List<GiftDTO>();
            var list = await GetListAsync();
            foreach (var item in list)
            {
                giftDTOs.Add(_mapper.Map<GiftDTO>(item));
            }
            foreach (var item in giftDTOs)
            {
                if (/*item.EndingAge>=Age&&*/item.Gender == Gender && (Events == 0 || Events == item.Events) && (Categry == 0 || Categry == item.Categry))
                    helping.Add(item);
            }
            giftDTOs = helping;
            helping = new List<GiftDTO>();
            double start = 0, end = 120;
            if (Age >= 0)
            {
                if (Age >= 90)
                {
                    start = 90;
                }
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

                        }
                    }
                }
            }
            foreach (var item in giftDTOs)
            {
                if (item.EndingAge <= end && item.StartingAge >= start)
                    helping.Add(item);
            }

            giftDTOs = helping;
            helping = new List<GiftDTO>();
            double startPrice = 0, endPrice = 100000000;
            if (EstimatedPrice >= 0)
            {
                startPrice = EstimatedPrice + Math.Min(EstimatedPrice, EstimatedPrice < 100 ? 30 : EstimatedPrice < 1000 ? EstimatedPrice * 0.22 : EstimatedPrice * 0.3);
                endPrice = EstimatedPrice - startPrice + EstimatedPrice;
            }

            foreach (var item in giftDTOs)
            {
                if (item.EstimatedPrice <= endPrice && item.EstimatedPrice >= startPrice)
                    helping.Add(item);
            }
            return giftDTOs;
        }

        public async Task<List<GiftDTO>> GetListAsync()
        {
            var list = await _repository.GetListAsync();
            List<GiftDTO> giftDTOs = new List<GiftDTO>();
            foreach (var item in list)
            {
                giftDTOs.Add(_mapper.Map<GiftDTO>(item));
            }
            return giftDTOs;

        }

        public async Task<List<OpinionDTO>> GetOpinionAsync(int giftId)
        {
            var list = await _repository.GetOpinionAsync(giftId);
            List<OpinionDTO> opDTOs = new List<OpinionDTO>();
            foreach (var item in list)
            {
                opDTOs.Add(_mapper.Map<OpinionDTO>(item));
            }
            return opDTOs;
        }
    }
}
