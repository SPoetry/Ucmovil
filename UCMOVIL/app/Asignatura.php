<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Asignatura extends Model
{
  use Notifiable;

  /**
   * The attributes that are mass assignable.
   *
   * @var array
   */
  protected $fillable = [
      'id_asignatura', 'id_malla', 'nombre',
      'creditos', 'requisito',
  ];
  public function historial(){
    return $this->hasMany('App\Historial');
  }
  public function malla(){
    return $this->hasMany('App\Malla');
  }
  public function ramosactuale(){
    return $this->hasMany('App\RamosActuale');
  }
  public function horario(){
    return $this->hasMany('App\Horario');
  }
  public function ramosimpartido(){
    return $this->hasMany('App\RamosImpartido');
  }
  public function nota(){
    return $this->hasMany('App\Nota');
  }
}
