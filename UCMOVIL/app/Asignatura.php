<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Asignatura extends Model
{

  protected $fillable = [
      'id_asignatura', 'id_malla', 'nombre',
      'creditos', 'prerequisito', 'posicion_x', 'posicion_y'
  ];
  public function historial(){
    return $this->hasMany(Hisotiale::class, 'id_asignatura', 'id_asignatura');
  }
  public function horario(){
    return $this->hasMany(Horario::class, 'id_asignatura', 'id_asignatura');
  }
  public function versionramo(){
    return $this->hasMany(VersionRamo::class, 'id_asignatura', 'id_asignatura');
  }
}
