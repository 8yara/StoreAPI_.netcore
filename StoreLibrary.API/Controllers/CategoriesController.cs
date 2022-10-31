using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreLibrary.API.Services;
using StoreLibrary.API.Entities;
using System.Net.Http;
using System.Threading;
using AutoMapper;
using StoreLibrary.API.Models;
using CoreApiResponse;
using System.Net;
using Microsoft.AspNetCore.Cors;

namespace StoreLibrary.API.Controllers
{
    [ApiController]
 

    public class CategoriesController : BaseController
    {
        private readonly IStoreLibraryRepository _storeLibraryRepository;

        public IMapper _mapper { get; }

        public CategoriesController(IStoreLibraryRepository storeLibraryRepository
            ,IMapper mapper)

        {
            _storeLibraryRepository = storeLibraryRepository ??
                throw new ArgumentNullException(nameof(storeLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

   
        //GET: /categories
        [HttpGet("api/categories")]
        public IActionResult GetCategories()
        {
          var CategoriesFromRepo = _storeLibraryRepository.GetCategories();
            return CustomResult("Data Loaded Successfully", _mapper.Map<IEnumerable<CategoryDTO>>(CategoriesFromRepo));
            //return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(CategoriesFromRepo));
        }


    }
}
