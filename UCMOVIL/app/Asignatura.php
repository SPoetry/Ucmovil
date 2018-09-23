<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Asignatura extends Model
{

  protected $fillable = [
      'id_asignatura', 'id_malla', 'nombre',
      'creditos', 'requisito',
  ];
  public function historial(){
    return $this->hasMany(Hisotiale::class, 'id_asignatura', 'id_asignatura');
  }
  public function malla(){
    return $this->hasMany(Malla::class, 'id_asignatura', 'id_asignatura');
  }
  public function ramosactuale(){
    return $this->hasMany(RamosActuale::class, 'id_asignatura', 'id_asignatura');
  }
  public function horario(){
    return $this->hasMany(Horario::class, 'id_asignatura', 'id_asignatura');
  }
  public function ramosimpartido(){
    return $this->hasMany(RamosImpartido::class, 'id_asignatura', 'id_asignatura');
  }
}
