<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class VersionRamo extends Model
{
  protected $fillable = [
      'id_asignatura', 'id_profesor', 'year', 'semestre',
  ];
  public function profesore(){
    return $this->belongsTo('App\Profesore');
  }
  public function asignatura(){
    return $this->belongsTo('App\Asignatura');
  }
  public function ramosactuale(){
    return $this->hasMany(RamosActuale::class, 'id_ramo', 'id_ramo');
  }

}
