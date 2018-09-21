<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Alumno extends Model
{
  use Notifiable;

  /**
   * The attributes that are mass assignable.
   *
   * @var array
   */
  protected $fillable = [
      'id_alumno', 'ano_ingreso', 'nombre',
      'email', 'ano_nacimiento', 'telefono',
      'direccion', 'semestre_actual', 'id_alumno',
  ];

  public function user(){
    return $this->hasOne('App\User');
  }
  public function historiale(){
    return $this->hasMany('App\Historiale');
  }
  public function ramosactuale(){
    return $this->hasMany('App\RamosAcetuale');
  }
  public function nota(){
    return $this->hasMany('App\Nota');
  }
}
