using System;
using System.Collections.Generic;
using System.Linq;
using ASPNETCore5Sample.Models;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace ASPNETCore5Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<TEntity, TPKey, TCreateViewModel, TUpdateViewModel> : ControllerBase where TEntity : class
    {
        /// <summary>
        /// Entity Key Field Name
        /// </summary>
        public string PKeyName { get; set; } = "Id";

        protected readonly ContosoUniversityContext _db;
        public BaseCRUDController(ContosoUniversityContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// ���o�Ҧ����
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public virtual ActionResult<IEnumerable<TEntity>> GetEntitys()
        {
            return _db.Set<TEntity>().ToList();
        }

        /// <summary>
        /// ���o�浧���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual ActionResult<TEntity> GetEntityById(TPKey id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// �s�W�浧���
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("")]
        public virtual ActionResult<TEntity> PostEntity(TCreateViewModel model)
        {
            TEntity addEntity = Activator.CreateInstance<TEntity>();
            addEntity.InjectFrom(model);
            _db.Add(addEntity);                       
            _db.SaveChanges();            

            var id = addEntity.GetType().GetProperty(PKeyName).GetValue(addEntity);
            return Created($"{this.HttpContext.Request.Path.Value}/{id}", addEntity);
        }

        /// <summary>
        /// ��s�浧���
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public virtual ActionResult PutEntity(TPKey id, TUpdateViewModel model)
        {
            var updateEntity = _db.Set<TEntity>().Find(id);
            updateEntity.InjectFrom(model);

            _db.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// �R���浧���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual ActionResult<TEntity> DeleteEntityById(TPKey id)
        {
            TEntity delEntity = _db.Set<TEntity>().Find(id);
            _db.Remove(delEntity);

            _db.SaveChanges();

            return Ok();
        }
    }
}