﻿using AutoMapper;
using CarProject.Data.Contexts;

namespace CarProject.Data.Services;

public class DbService : IDbService
{
    private readonly CarShopContext _db;
    private readonly IMapper _mapper;

    public DbService(CarShopContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public virtual async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity : class
        where TDto : class
    {
        //IncludeNavigationsFor<TEntity>();
        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }

    public virtual async Task<TDto> SingleAsync<TEntity, TDto>(int id) where TEntity : class, IEntity where TDto : class
    {
        var entity = await _db.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
        return _mapper.Map<TDto>(entity);
    }
    public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto) where TEntity : class where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _db.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task<bool> SaveChangesAsync() => await _db.SaveChangesAsync() >= 0;

    public void Update<TEntity, TDto>(TDto dto)
    where TEntity : class, IEntity where TDto : class
    {
        // Note that this method isn't asynchronous because Update modifies
        // an already exisiting object in memory, which is very fast.
        var entity = _mapper.Map<TEntity>(dto);
        _db.Set<TEntity>().Update(entity);
    }

    public async Task<bool> DeleteAsync<TEntity>(int id)
        where TEntity : class, IEntity
    {
        try
        {
            var entity = await _db.Set<TEntity>()
                .SingleOrDefaultAsync(e => e.Id == id);

            if (entity is null) return false;
            _db.Remove(entity);
        }
        catch { return false; }

        return true;
    }

}
