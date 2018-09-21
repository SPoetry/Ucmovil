<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class DirectoresCarrera extends Model
{
  use Notifiable;

  /**
   * The attributes that are mass assignable.
   *
   * @var array
   */
  protected $fillable = [
      'id_director', 'especialidad', 'nombre',
      'email', 'telefono', 'id_director',
  ];

  public function user(){
    return $this->hasOne('App\User');
  }
}
