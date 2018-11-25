<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Builder;

class RamosActuale extends Model
{
  protected $primaryKey = ['id_ramo', 'id_alumno', 'n_nota'];
  public $incrementing = false;

  protected $fillable = [
      'id_ramo', 'id_alumno', 'nota', 'n_nota'
  ];
  

  protected function setKeysForSaveQuery(Builder $query)
  {
      $keys = $this->getKeyName();
      if(!is_array($keys)){
          return parent::setKeysForSaveQuery($query);
      }
  
      foreach($keys as $keyName){
          $query->where($keyName, '=', $this->getKeyForSaveQuery($keyName));
      }
  
      return $query;
  }
  
  /**
   * Get the primary key value for a save query.
   *
   * @param mixed $keyName
   * @return mixed
   */
  protected function getKeyForSaveQuery($keyName = null)
  {
      if(is_null($keyName)){
          $keyName = $this->getKeyName();
      }
  
      if (isset($this->original[$keyName])) {
          return $this->original[$keyName];
      }
  
      return $this->getAttribute($keyName);
  }


  public function alumno(){
    return $this->belongsTo(Alumno::class, 'id_alumno', 'id');
  }
  public function versionramo(){
    return $this->belongsTo(VersionRamo::class, 'id_ramo', 'id_ramo');
  }


}

